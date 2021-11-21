import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native';

export default class Login extends Component {

    realizarLogin = () => {
        this.props.navigation.navigate('Main')
    }

  render(){
    return (
      <View style={styles.main}>
          
          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this.realizarLogin}
          >
            <Text>Login</Text>
            
          </TouchableOpacity>
        
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
  },

  btnLogin: {
    alignItems: "center",
    justifyContent: "center",
    height: 38,
    width: 240,
    backgroundColor: "#FFFFFF",
    borderColor: "#FFFFFF",
    borderWidth: 1,
    borderRadius: 4,
    shadowOffset: { height: 1, width: 1 },
  }

});