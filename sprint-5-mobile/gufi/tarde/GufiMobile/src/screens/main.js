import React, { Component } from 'react';
import {
  Image,
  StatusBar,
  StyleSheet,
  View,
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();

import Convites from './convites';
import Eventos from './eventos';
import Perfil from './perfil';

export default class Main extends Component {
  
  render() {
    return (
      <View style={styles.main}>
        <StatusBar 
          hidden={false}
          // backgroundColor={'black'}
        />

          <bottomTab.Navigator
            initialRouteName='Eventos'

            // React Navigation 5.x
            // tabBarOptions={{
            //   showLabel : false,
            //   showIcon : true,
            //   activeBackgroundColor: '#B727FF',
            //   inactiveBackgroundColor: '#DD99FF',
            //   activeTintColor: 'red',
            //   inactiveTintColor: 'blue',
            //   style: { height: 50 }
            // }}

            screenOptions={ ({ route }) => ({
              tabBarIcon: () => {
                if (route.name === 'Convites') {
                  return(
                    <Image 
                      source={require('../../assets/img/plane.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }
                if (route.name === 'Eventos') {
                  return(
                    <Image 
                      source={require('../../assets/img/calendar.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }
                if (route.name === 'Perfil') {
                  return(
                    <Image 
                      source={require('../../assets/img/profile.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }
              },

              // React Navigation 6.x
              headerShown: false,
              tabBarShowLabel: false,
              tabBarActiveBackgroundColor: '#B727FF',
              tabBarInactiveBackgroundColor: '#DD99FF',
              // tabBarActiveTintColor: 'red',
              // tabBarInactiveTintColor: 'blue',
              tabBarStyle: { height: 50 }
            }) }
          >

            <bottomTab.Screen name="Convites" component={Convites} />
            <bottomTab.Screen name="Eventos" component={Eventos} />
            <bottomTab.Screen name="Perfil" component={Perfil} />

          </bottomTab.Navigator>

      </View>
    );
  }
};

const styles = StyleSheet.create({
  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#F1F1F1'
  },
   // estilo dos ícones da tabBar
   tabBarIcon: {
    width: 22,
    height: 22
  }
});
