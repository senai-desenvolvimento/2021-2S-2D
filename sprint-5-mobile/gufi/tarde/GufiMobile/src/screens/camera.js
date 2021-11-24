import React, {useState} from 'react';
import {
  Alert,
  Modal,
  View,
  Image,
  ImageBackground,
  TouchableOpacity,
  StyleSheet,
  Text,
  Touchable,
} from 'react-native';

import {RNCamera} from 'react-native-camera';
import topo from '../../assets/img/profile2x.png';

import ImgToBase64 from 'react-native-image-base64';

import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';
import {useNavigation} from '@react-navigation/native';

const Camera = ({isVisible, onChangePhoto, onCloseCamera}) => {
  const [camera, setCamera] = useState();
  const onTakePicture = async () => {
    try {
      const {uri} = await camera.takePictureAsync({
        quality: 0.5,
        forceUpOrientation: true,
        fixOrientation: true,
        skipProcessing: true,
      });
      onChangePhoto(uri);
    } catch (error) {
      Alert.alert('Erro', 'Houve um erro ao tirar a foto.');
    }
  };

  return (
    <Modal animationType="slide" transparent={false} visible={isVisible}>
      <RNCamera
        ref={ref => setCamera(ref)}
        style={{flex: 1}}
        type={RNCamera.Constants.Type.back}
        autoFocus={RNCamera.Constants.AutoFocus.on}
        flashMode={RNCamera.Constants.FlashMode.off}
        androidCameraPermissionOptions={{
          title: 'Permissão oara usar a câmera',
          message: 'Precisamos da sua permissão para usar a câmera.',
          buttonPositive: 'OK',
          buttonNegative: 'Cancelar',
        }}
        captureAudio={false}>
        <View style={styles.snapWrapper}>
          <TouchableOpacity onPress={onTakePicture} style={styles.capture}>
            <Text style={styles.snapText}>Foto</Text>
          </TouchableOpacity>
        </View>
      </RNCamera>
    </Modal>
  );
};

const CameraPerfil = () => {
  const [isCameraVisible, setIsCameraVisible] = useState(false);
  const [photo, setPhoto] = useState(null);
  const navigation = useNavigation();

  const onChangePhoto = newPhoto => {
    console.warn(newPhoto);

    //recuperar o caminho da img e conversão para
    //base 64.
    ImgToBase64.getBase64String(newPhoto)
      .then(base64String => console.warn(base64String))
      .catch(err => console.warn(err));

    setPhoto(newPhoto);
    setIsCameraVisible(false);
  };
  const onCloseCamera = () => {
    setIsCameraVisible(false);
  };

  const Confirmar = async () => {
    const token = await AsyncStorage.getItem('userToken');

    var foto_confirmada = {
      uri: photo,
      type: 'image/jpeg',
      name: 'photo.jpg',
    };
    const formData = new FormData();
    formData.append('arquivo', foto_confirmada);

    api
      .post('/perfils/imagem/bd', formData, {
        headers: {
          Authorization: 'Bearer ' + token,
        },
      })
      .then(resposta => {
        if (resposta.status == 200) {
          console.warn('Foto de perfil salva.');
          navigation.goBack();
          //voltar para pagina anterior.
        }
      })
      .catch(error => console.warn(error));
  };

  return (
    <View style={styles.container}>
      <Image source={topo} style={styles.topo} />
      <View style={styles.photo}>
        <ImageBackground
          source={{uri: photo}}
          style={{width: '100%', height: '100%'}}
        />
      </View>
      <View style={styles.buttons}>
        <TouchableOpacity
          style={styles.button}
          onPress={() => {
            setIsCameraVisible(true);
          }}>
          <Text>Abrir</Text>
        </TouchableOpacity>
        <TouchableOpacity
          style={styles.button}
          onPress={() => {
            Confirmar();
          }}>
          <Text>Confirmar</Text>
        </TouchableOpacity>
      </View>
      <Camera
        isVisible={isCameraVisible}
        onChangePhoto={onChangePhoto}
        onCloseCamera={onCloseCamera}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#bcbcbc',
  },
  topo: {
    alignSelf: 'center',
    marginTop: 60,
  },
  photo: {
    width: 300,
    height: 200,
    backgroundColor: '#fff',
    alignSelf: 'center',
    marginTop: 80,
  },
  buttons: {
    marginTop: 10,
    flexDirection: 'row',
    justifyContent: 'center',
  },
  button: {
    backgroundColor: '#fff',
    margin: 20,
    borderRadius: 150,
    width: 80,
    height: 80,
    alignItems: 'center',
    justifyContent: 'center',
  },
  buttonTakePicture: {
    flex: 0,
    alignSelf: 'center',
    position: 'absolute',
    bottom: 20,
  },
  buttonCloseCamera: {
    flex: 0,
    position: 'absolute',
    top: 20,
    right: 20,
  },

  snapWrapper: {
    flex: 0,
    flexDirection: 'row',
    justifyContent: 'center',
    backgroundColor: 'rgba(0, 0, 0, 0)',
    position: 'absolute',
    top: 280,
    left: 16,
    right: 16,
  },
  snapText: {
    fontSize: 14,
    color: 'red',
  },
  capture: {
    flex: 0,
    backgroundColor: '#fff',
    borderRadius: 5,
    padding: 15,
    paddingHorizontal: 20,
    alignSelf: 'center',
    margin: 20,
  },
});

export default CameraPerfil;
