import Vue from "vue";
import './plugins/vuetify';
import App from "./App.vue";
import 'vuetify/dist/vuetify.min.css';
import './stylus/main.styl';
import Vuebar from 'vuebar';

import store from './store'
import { types as authTypes } from './store/auth'
import router from "./router"
import axios from './http'
import { configureAxios } from './http/axios'

configureAxios(axios)

Vue.prototype.$http = axios

store.dispatch(`${authTypes.name}/${authTypes.actions.onAutoLogin}`)

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");

Vue.use(Vuebar);
