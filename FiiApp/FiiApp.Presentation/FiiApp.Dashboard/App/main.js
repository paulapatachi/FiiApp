// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import 'core-js/es6/promise'
import 'core-js/es6/string'
import 'core-js/es7/array'
// import cssVars from 'css-vars-ponyfill'
import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import App from './App'
import router from './router'
import store from './store'
import Axios from 'axios'

// todo
// cssVars()

Vue.use(BootstrapVue)

Vue.prototype.$http = Axios;

const accessToken = localStorage.getItem('access_token')

if (accessToken) {
  Vue.prototype.$http.defaults.headers.common['Authorization'] = 'Bearer ' + accessToken
}

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  template: '<App/>',
  components: {
    App
  }
})
