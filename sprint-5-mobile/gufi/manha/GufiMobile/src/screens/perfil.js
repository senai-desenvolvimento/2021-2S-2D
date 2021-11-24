import React, {Component} from 'react';
import {
  StyleSheet,
  Text,
  View,
  Image,
  TouchableOpacity,
  PendingView,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';
import api from '../services/api';

export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: '',
      email: '',
      base64: '',
    };
  }

  consultaImgPerfil = async () => {
    const valorToken = await AsyncStorage.getItem('userToken');

    api
      .get('/perfil/imagem/bd', {
        headers: {
          Authorization: 'Bearer ' + valorToken,
        },
      })
      .then(resposta => {
        if (resposta.status == 200) {
          console.warn(resposta.data);
          this.setState({base64: resposta.data});
        }
      })
      .catch(erro => console.warn(erro));
  };

  buscarDadosStorage = async () => {
    try {
      const valorToken = await AsyncStorage.getItem('userToken');

      console.warn(jwtDecode(valorToken));

      if (valorToken != null) {
        this.setState({nome: jwtDecode(valorToken).name});
        this.setState({email: jwtDecode(valorToken).email});
      }
    } catch (error) {
      console.warn(error);
    }
  };

  componentDidMount() {
    this.buscarDadosStorage();
    this.consultaImgPerfil();
  }

  realizarLogout = async () => {
    //vamos remover o armazenamento local.
    try {
      await AsyncStorage.removeItem('userToken');
      this.props.navigation.navigate('Login'); //tem que ser mesmo nome.
    } catch (error) {
      console.warn(error);
    }
  };

  render() {
    return (
      <View style={styles.main}>
        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.buttonContainer}>
            <TouchableOpacity
              onPress={this.takePicture}
              style={styles.capture}></TouchableOpacity>
          </View>
          <View style={styles.mainHeaderRow}>
            <Image
              source={require('../../assets/img/profile.png')}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{'Perfil'.toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
            {/* <Image 
              source={imagem vinda da API}
              style={styles.mainBodyImg}
            /> */}
            {/* <View style={styles.mainBodyImg} /> */}
            <TouchableOpacity
              onPress={() => this.props.navigation.navigate('Camera')}>
              <Image
                source={{uri: `data:image/png;base64,${this.state.base64}`}}
                style={styles.mainBodyImg}
              />
            </TouchableOpacity>

            <Text style={styles.mainBodyText}>{this.state.nome}</Text>
            <Text style={styles.mainBodyText}>{this.state.email}</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.realizarLogout}>
            <Text style={styles.btnLogoutText}>sair</Text>
          </TouchableOpacity>
        </View>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1',
  },
  // cabeçalho
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  mainHeaderRow: {
    flexDirection: 'row',
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 22,
    height: 22,
    tintColor: '#ccc',
    marginRight: -5,
    marginTop: -12,
  },
  // texto do cabeçalho
  mainHeaderText: {
    fontSize: 16,
    letterSpacing: 5,
    color: '#999',
    fontFamily: 'Open Sans',
  },
  // linha de separação do cabeçalho
  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: '#999',
    borderBottomWidth: 1,
  },

  // conteúdo do body
  mainBody: {
    flex: 4,
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center',
  },
  mainBodyImg: {
    backgroundColor: '#ccc',
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 50,
  },
  mainBodyText: {
    color: '#999',
    fontSize: 16,
    marginBottom: 20,
  },
  // botão de logout
  btnLogout: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 80,
    width: 240,
    borderTopWidth: 1,
    borderColor: '#ccc',
    marginBottom: 50,
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 16,
    fontFamily: 'Open Sans',
    color: '#B727FF',
  },
});
