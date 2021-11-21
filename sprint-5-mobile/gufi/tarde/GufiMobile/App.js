import 'react-native-gesture-handler';

import React from 'react';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const AuthStack = createStackNavigator();

import Login from './src/screens/login';
import Main from './src/screens/main';

export default function Stack(){
  return(
    <NavigationContainer>

      <AuthStack.Navigator
        // initialRouteName='Login'
        // screenOptions={{
        //   headerShown: false
        // }}
      >

        <AuthStack.Screen name="Login" component={Login} />
        <AuthStack.Screen name="Main" component={Main} />

      </AuthStack.Navigator>

    </NavigationContainer>
  )
}