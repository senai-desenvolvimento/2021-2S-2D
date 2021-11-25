import React, {Component} from 'react';
import {FlatList, Image, StyleSheet, Text, View} from 'react-native';

import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';

import {TouchableOpacity} from 'react-native-gesture-handler';

export default class Convites extends Component {
  constructor(props) {
    super(props);
    this.state = {
      listaMeusEventos: [],
    };
  }

  // define a função que faz a chamada para a API e traz os eventos
  buscarMeusEventos = async () => {
    try {
      const token = await AsyncStorage.getItem('userToken');

      const resposta = await api.get('/Presencas/minhas', {
        headers: {
          Authorization: 'Bearer ' + token,
        },
      });

      if (resposta.status === 200) {
        const dadosDaApi = resposta.data;
        this.setState({listaMeusEventos: dadosDaApi});
      }
    } catch (error) {
      console.warn(error);
    }
  };

  // quando o componente é renderizado
  componentDidMount() {
    // invoca a função abaixo
    this.buscarMeusEventos();
  }

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
            <Text style={styles.mainHeaderText}>
              {'Convites'.toUpperCase()}
            </Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body */}
        <View style={styles.mainBody}>
          <TouchableOpacity
            onPress={this.buscarMeusEventos}
            style={{alignItems: 'center'}}>
            <Text style={(styles.flatItemTitle, {color: '#b727FF'})}>
              Atualizar Convites
            </Text>
          </TouchableOpacity>
          <FlatList
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.listaMeusEventos}
            keyExtractor={item => item.idEvento}
            renderItem={this.renderItem}
          />
        </View>
      </View>
    );
  }

  renderItem = ({item}) => (
    <View style={styles.flatItemRow}>
      <View style={styles.flatItemContainer}>
        <Text style={styles.flatItemTitle}>
          {item.idEventoNavigation.nomeEvento}
        </Text>
        <Text style={styles.flatItemInfo}>
          {item.idEventoNavigation.descricao}
        </Text>
        <Text style={styles.flatItemInfo}>
          {Intl.DateTimeFormat("pt-BR", {
                                year: 'numeric', month: 'numeric', day: 'numeric',
                                hour: 'numeric', minute: 'numeric',
                                hour12: true                                                
                            }).format(new Date(item.idEventoNavigation.dataEvento))}
        </Text>
        <Text style={styles.flatItemInfo}>
          {item.idSituacaoNavigation.descricao}
        </Text>
      </View>
      <View style={styles.flatItemImg}>
        <Image
          source={
            item.idSituacao === 1
              ? require('../../assets/img/check-symbol.png')
              : require('../../assets/img/no-check-symbol.png')
          }
          style={styles.flatItemImgIcon}
        />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  // unidades de medida

  // porcentagem
  // ex: height: '50%'

  // px
  // ex: height: 50 (não é necessário colocar a unidade de medida px)

  // proporção
  // ex: flex: 1

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
    width: 16,
    height: 16,
    //tintColor: '#B727FF',
  },
});
