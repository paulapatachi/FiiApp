import Vue from 'vue'
import Vuex from 'vuex'
import { state, mutations } from './mutations'
import { actions } from './actions'

import axios from 'axios'

Vue.use(Vuex)

//export default new Vuex.Store({
//  state,
//  mutations,
//  actions
//})


export default new Vuex.Store({
  state: {
    status: '',
    token: localStorage.getItem('access_token') || '',
    currentUser: {}
  },

  mutations: {
    auth_request(state) {
      state.status = 'loading'
    },
    auth_success(state, payload) {
      state.status = 'success'
      state.token = payload.token
      state.currentUser = payload.currentUser
    },
    auth_error(state) {
      state.status = 'error'
    },
    logout(state) {
      state.status = ''
      state.token = ''
      state.currentUser = {}
    },
  },

  actions: {
    login({ commit }, user) {
      return new Promise((resolve, reject) => {
        commit('auth_request')
        let theurl = document.getElementById('axiosUrls').getAttribute('data-loginTokenUrl')
        axios({
          url: theurl,
          params: {
            username: user.username,
            password: user.password
          },
          method: 'POST'
        })
          .then(resp => {
            const token = resp.data.token
            const currentUser = resp.data
            localStorage.setItem('access_token', token)
            axios.defaults.headers.common['Authorization'] = 'Bearer ' + token
            commit('auth_success', { token: token, currentUser: currentUser })
            resolve(resp)
          })
          .catch(err => {
            commit('auth_error')
            localStorage.removeItem('access_token')
            reject(err)
          })
      })
    },

    register({ commit }, user) {
      return new Promise((resolve, reject) => {
        commit('auth_request')
        let theurl = document.getElementById('axiosUrls').getAttribute('data-registerUrl')
        axios({
          url: theurl,
          params: {
            registrationNumber: user.registrationNumber,
            email: user.email,
            password: user.password
          },
          method: 'POST'
        })
          .then(resp => {
            const token = resp.data.token
            const currentUser = resp.data
            localStorage.setItem('access_token', token)
            axios.defaults.headers.common['Authorization'] = 'Bearer ' + token
            commit('auth_success', { token: token, currentUser: currentUser })
            resolve(resp)
          })
          .catch(err => {
            commit('auth_error', err)
            localStorage.removeItem('token')
            reject(err)
          })
      })
    },

    logout({ commit }) {
      return new Promise((resolve, reject) => {
        commit('logout')
        localStorage.removeItem('access_token')
        delete axios.defaults.headers.common['Authorization']
        resolve()
      })
    }
  },
  getters: {
    isLoggedIn: state => !!state.token,
    authStatus: state => state.status,
  }
})
