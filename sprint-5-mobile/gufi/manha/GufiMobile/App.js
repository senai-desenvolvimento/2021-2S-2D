import 'react-native-gesture-handler';

import React, {Component} from 'react';

import {NavigationContainer} from '@react-navigation/native';
import {createStackNavigator} from '@react-navigation/stack';

import {StyleSheet, View} from 'react-native';

import Main from './src/screens/main';
import Login from './src/screens/login';

const AuthStack = createStackNavigator();

class App extends Component {
  render() {
    return (
      <NavigationContainer>
        <AuthStack.Navigator
          screenOptions={{
            headerShown: false,
          }}>
          <AuthStack.Screen name="Login" component={Login} />
          <AuthStack.Screen name="Main" component={Main} />
        </AuthStack.Navigator>
      </NavigationContainer>
    );
  }
}

const styles = StyleSheet.create({
  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1',
  },

  // estilo dos ícones da tabBar
  tabBarIcon: {
    width: 22,
    height: 22,
  },
});

export default App;
