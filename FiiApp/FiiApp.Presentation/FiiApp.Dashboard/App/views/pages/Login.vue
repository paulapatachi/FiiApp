<template>
  <div class="app flex-row align-items-center">
    <div class="container">
      <b-row class="justify-content-center">
        <b-col md="8">
          <b-card-group>
            <b-card no-body class="p-4">
              <b-card-body>
                <b-form v-on:submit.prevent="login" novalidate>
                  <h1>Login</h1>
                  <p class="text-muted">Sign In to your account</p>
                  <b-input-group class="mb-3">
                    <b-input-group-prepend><b-input-group-text><i class="icon-user"></i></b-input-group-text></b-input-group-prepend>
                    <b-form-input v-model="username" :state="validCredentials" type="text" class="form-control" placeholder="Username" autocomplete="username email" />
                  </b-input-group>
                  <b-input-group class="mb-4">
                    <b-input-group-prepend><b-input-group-text><i class="icon-lock"></i></b-input-group-text></b-input-group-prepend>
                    <b-form-input v-model="password" :state="validCredentials" type="password" class="form-control" placeholder="Password" autocomplete="current-password" />
                    <b-form-invalid-feedback>
                      Username or password incorrect
                    </b-form-invalid-feedback>
                  </b-input-group>
                  <b-row>
                    <b-col cols="6">
                      <b-button type="submit" variant="primary" class="px-4">Login</b-button>
                    </b-col>
                    <!--<b-col cols="6" class="text-right">
                      <b-button variant="link" href="#/register" class="px-0">Go to Register?</b-button>
                    </b-col>-->
                  </b-row>
                </b-form>
              </b-card-body>
            </b-card>
            <b-card no-body class="text-white bg-primary py-5 d-md-down-none" style="width:44%">
              <b-card-body class="text-center">
                <div>
                  <h2>Sign up</h2>
                  <p>If you do not have an account for FiiApp, you can create one using your registration number and webmail address.</p>
                  <b-button variant="primary" class="active mt-3" to="register">Register Now!</b-button>
                </div>
              </b-card-body>
            </b-card>
          </b-card-group>
        </b-col>
      </b-row>
    </div>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
    name: 'Login',
    data() {
      return {
        username: null,//'paula.patachi',
        password: null, //'paula',
        validCredentials: null
      }
    },

    methods: {
      loginCurrentUser() {
        console.log('Username: ' + this.$data.username)
        console.log('Password: ' + this.$data.password)
        //this.$router.push('/info');
        this.$router.push({ name: 'StudentInfo', params: { username: this.$data.username, password: this.$data.password } })
        this.getToken()
      },

      getToken() {
        let url = document.getElementById('axiosUrls').getAttribute('data-loginTokenUrl')
        axios.post(url, null, {
          params: {
            username: this.$data.username,
            password: this.$data.password
          }
        })
          .then(response => {
            console.log('--------------------------------------------------------------------')
            console.log(response)
            console.log(response.data)
            localStorage.setItem('access_token', response.data)
            console.log(localStorage)
            console.log('--------------------------------------------------------------------')
          })
      },

      login () {
        let username = this.$data.username
        let password = this.$data.password
        this.$store.dispatch('login', { username, password })
          .then(() => this.$router.push('/dashboard'))
          .catch(err => {
            this.validCredentials = false
            this.password = null
          })
      }
    }
}
</script>
