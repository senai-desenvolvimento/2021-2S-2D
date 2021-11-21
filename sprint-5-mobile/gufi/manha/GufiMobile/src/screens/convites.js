import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  View,
} from 'react-native';

export default class Convites extends Component {

  render(){
    return (
      <View style={styles.main}>
        <Text>Convites</Text>
      </View>
    );
  }
  
};

const styles = StyleSheet.create({

  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1',
    justifyContent: 'center',
    alignItems: 'center'
  }

});