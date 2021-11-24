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
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../services/api';

import {useNavigation} from '@react-navigation/native';

const Camera = ({isVisible, onChangeFoto, onCloseCamera}) => {
  const [camera, SetCamera] = useState();
  const onTakePicture = async () => {
    try {
      const {uri} = await camera.takePictureAsync({
        quality: 0.5,
        forceUpOrientation: true,
        fixOrientation: true,
        skipProcessing: true,
      });
      onChangeFoto(uri);
    } catch (error) {
      Alert.alert('Erro', 'Houve um erro ao tirar a foto.');
    }
  };

  return (
    <Modal animationType="slide" transparent={false} visible={isVisible}>
      <RNCamera
        ref={ref => SetCamera(ref)}
        style={{flex: 1}}
        type={RNCamera.Constants.Type.back}
        autoFocus={RNCamera.Constants.AutoFocus.on}
        flashMode={RNCamera.Constants.FlashMode.off}
        androidCameraPermissionOptions={{
          title: 'Permissão para usar a câmera',
          message: 'Precisamos da sua permissão para usar câmera',
          buttonPositive: 'Ok',
          buttonNegative: 'Cancelar',
          buttonNeutral: 'teste',
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
  const [isCameraVisible, SetisCameraVisible] = useState(false);
  const [photo, setPhoto] = useState(null);
  const navigation = useNavigation();

  const onChangeFoto = async newPhoto => {
    console.warn(newPhoto);

    ImgToBase64.getBase64String(newPhoto)
      .then(base64String => console.warn(base64String))
      .catch(err => doSomethingWith(err));

    console.warn(photo);

    setPhoto(newPhoto);
    SetisCameraVisible(false);
  };

  const onCloseCamera = () => {
    SetisCameraVisible(false);
  };

  const Confirmar = async () => {
    //
    const token = await AsyncStorage.getItem('userToken');

    var photo1 = {
      uri: photo,
      type: 'image/jpeg',
      name: 'photo.jpg',
    };
    const formData = new FormData();
    formData.append('arquivo', photo1);

    api
      .post('/perfil/imagem/bd', formData, {
        headers: {
          Authorization: 'Bearer ' + token,
        },
      })
      .then(resposta => {
        if (resposta.status == 200) {
          console.warn('Fonto de perfil salva.');
          navigation.goBack(); //volta para pagina anterior.
        }
      })
      .catch(erro => console.warn(erro));
  };

  return (
    <View style={styles.container}>
      <Image source={topo} style={styles.topo} />
      <View style={styles.photo}>
        <ImageBackground
          style={{width: '100%', height: '100%'}}
          source={{uri: photo}}></ImageBackground>
      </View>
      <View style={styles.buttons}>
        <TouchableOpacity
          style={styles.button}
          onPress={() => {
            SetisCameraVisible(true);
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
        onChangeFoto={onChangeFoto}
        onCloseCamera={onCloseCamera}></Camera>
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
