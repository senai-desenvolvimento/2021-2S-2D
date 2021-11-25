import React, {Component} from 'react';
import {FlatList, Image, StyleSheet, Text, View} from 'react-native';

import api from '../services/api';

import {TouchableOpacity} from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Eventos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaEventos: [],
    };
  }

  buscarEventos = async () => {
    const resposta = await api.get('/eventos');
    // console.warn(resposta);
    const dadosDaApi = resposta.data;
    this.setState({listaEventos: dadosDaApi});
  };

  componentDidMount() {
    this.buscarEventos();
  }

  inscrever = async item => {
    try {
      const token = await AsyncStorage.getItem('userToken');

      const resposta = await api.post(
        '/presencas/inscricao/' + item,
        {},
        {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        },
      );
      if (resposta.status == 201) {
        console.warn('Inscrição realizada com sucesso.');
      } else {
        console.warn('Falha ao realizar inscrição.');
      }
    } catch (error) {
      console.warn(error);
    }
  };

  render() {
    return (
      <View style={styles.main}>
        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.mainHeaderRow}>
            <Image
              source={require('../../assets/img/calendar.png')}
              style={styles.mainHeaderImg}
            />
            <Text style={styles.mainHeaderText}>{'Eventos'.toUpperCase()}</Text>
          </View>

          <View style={styles.mainHeaderLine}></View>
        </View>

        {/* Corpo - Body */}
        <View style={styles.mainBody}>
          <FlatList
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.listaEventos}
            keyExtractor={item => item.idEvento}
            renderItem={this.renderItem}
          />
        </View>
      </View>
    );
  }

  renderItem = ({item}) => (
    // <Text style={{ fontSize: 20, color: 'red' }}>{item.nomeEvento}</Text>

    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitle}>{item.nomeEvento}</Text>
        <Text style={styles.flatItemInfo}>{item.descricao}</Text>

        <Text style={styles.flatItemInfo}>
          {Intl.DateTimeFormat("pt-BR", {
                            year: 'numeric', month: 'short', day: 'numeric',
                            hour: 'numeric', minute: 'numeric', hour12: true
                        }).format(new Date(item.dataEvento))}
        </Text>
      </View>

      <View style={styles.flatItemImg}>
        <TouchableOpacity
          onPress={() => this.inscrever(item.idEvento)}
          style={styles.flatItemImgIcon}>
          <Image source={require('../../assets/img/view.png')} />
        </TouchableOpacity>
      </View>
    </View>
  );
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
  },
  // conteúdo da lista
  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
  },
  // dados do evento de cada item da lista (ou seja, cada linha da lista)
  flatItemRow: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
    marginTop: 40,
  },
  flatItemContainer: {
    flex: 1,
  },
  flatItemTitle: {
    fontSize: 16,
    color: '#333',
  },
  flatItemInfo: {
    fontSize: 12,
    color: '#999',
    lineHeight: 24,
  },
  flatItemImg: {
    justifyContent: 'center',
  },
  flatItemImgIcon: {
    width: 26,
    height: 26,
    tintColor: '#B727FF',
  },
});
