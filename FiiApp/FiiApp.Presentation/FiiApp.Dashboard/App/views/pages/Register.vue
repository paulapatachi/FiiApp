<template>
  <div class="app flex-row align-items-center">
    <div class="container">
      <b-row class="justify-content-center">
        <b-col md="6" sm="8">
          <b-card no-body class="mx-4">
            <b-card-body class="p-4">
              <b-form v-on:submit.prevent="onSubmit" novalidate>
                <h1>Register</h1>
                <p class="text-muted">Create your account</p>

                <b-input-group class="mb-3">
                  <b-input-group-prepend>
                    <b-input-group-text><i class="fa fa-user-secret fa-lg"></i></b-input-group-text>
                  </b-input-group-prepend>
                  <b-form-input id="registrationNumber"
                                type="text"
                                v-model.lazy.trim="$v.form.registrationNumber.$model"
                                :state="chkState('registrationNumber')"
                                aria-describedby="input1LiveFeedback1"
                                placeholder="Registration Number"
                                autocomplete='registration-number' />
                  <b-form-invalid-feedback id="input1LiveFeedback1">
                    This is a required field and must be 16 characters
                  </b-form-invalid-feedback>
                </b-input-group>

                <b-input-group class="mb-3">
                  <b-input-group-prepend>
                    <b-input-group-text>@</b-input-group-text>
                  </b-input-group-prepend>
                  <b-form-input id="email"
                                type="email"
                                v-model.trim="$v.form.email.$model"
                                :state="chkState('email')"
                                aria-describedby="input1LiveFeedback4"
                                placeholder="Email"
                                autocomplete='email' />
                  <b-form-invalid-feedback id="input1LiveFeedback4">
                    This is a required field and must be valid e-mail address
                  </b-form-invalid-feedback>
                </b-input-group>

                <b-input-group class="mb-3">
                  <b-input-group-prepend>
                    <b-input-group-text><i class="icon-lock"></i></b-input-group-text>
                  </b-input-group-prepend>
                  <b-form-input id="password"
                                type="password"
                                v-model.trim="$v.form.password.$model"
                                :state="chkState('password')"
                                aria-describedby="input1LiveFeedback5"
                                placeholder="Password"
                                autocomplete='new-password' />
                  <b-form-invalid-feedback id="input1LiveFeedback5">
                    Password required
                  </b-form-invalid-feedback>
                </b-input-group>

                <b-input-group class="mb-3">
                  <b-input-group-prepend>
                    <b-input-group-text><i class="icon-lock"></i></b-input-group-text>
                  </b-input-group-prepend>
                  <b-form-input id="confirm_password"
                                type="password"
                                v-model.trim="$v.form.confirmPassword.$model"
                                :state="chkState('confirmPassword')"
                                aria-describedby="input1LiveFeedback6"
                                placeholder="Confirm password"
                                autocomplete='new-password' />
                  <b-form-invalid-feedback id="input1LiveFeedback6">
                    Passwords must match
                  </b-form-invalid-feedback>
                </b-input-group>

                <p v-if="registerError" class="errorColor">{{ registerErrorText }}</p>


                <b-button type="submit" variant="primary" block>Create Account</b-button>
              </b-form>

              <b-modal title="Your account has been successfully created!" class="modal-primary" v-model="confirmationModal" @hide="redirectToDashboard">
                Next time when you want to use this application you can login using
                the username from your webmail address and your password.
              </b-modal>

            </b-card-body>
          </b-card>
        </b-col>
      </b-row>
    </div>
  </div>
</template>

<script>
  import { validationMixin } from "vuelidate"
  import { required, minLength, maxLength, email, sameAs, helpers } from "vuelidate/lib/validators"

  const strongPass = helpers.regex('strongPass', /(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}/)


  //const formShape = {
  //  registrationNumber: "31090104SL140057",
  //  email: "andreea.bordeianu@info.uaic.ro",
  //  password: "andreea2019",
  //  confirmPassword: "andreea2019"
  //}

  const formShape = {
    registrationNumber: null,
    email: null,
    password: null,
    confirmPassword: null
  }

  export default {
    name: "ValidationForms",
    data() {
      return {
        form: Object.assign({}, formShape),
        confirmationModal: false,
        registerError: false,
        registerErrorText: ''
      }
    },
    computed: {
      formStr() { return JSON.stringify(this.form, null, 4) },
      isValid() { return !this.$v.form.$anyError },
      isDirty() { return this.$v.form.$anyDirty },
      invCheck() { return 'You must accept before submitting' },
    },
    mixins: [validationMixin],
    validations: {
      form: {
        registrationNumber: {
          required,
          minLength: minLength(16),
          maxLength: maxLength(16)
        },
        email: {
          required,
          email
        },
        password: {
          required,
          minLength: minLength(8),
        },
        confirmPassword: {
          required,
          sameAsPassword: sameAs("password")
        }
      }
    },
    methods: {
      onSubmit() {
        if (this.validate()) {
          this.$nextTick(() => {
            //console.log(this.form)
            this.register()
            
          })
        }
      },
      chkState(val) {
        const field = this.$v.form[val]
        if (!field.$dirty || !field.$invalid)
          return null
        return false
      },
      findFirstError(component = this) {
        if (component.state === false) {
          if (component.$refs.input) {
            component.$refs.input.focus()
            return true
          }
          if (component.$refs.check) {
            component.$refs.check.focus()
            return true
          }
        }
        let focused = false
        component.$children.some((child) => {
          focused = this.findFirstError(child)
          return focused
        })

        return focused
      },
      validate() {
        this.$v.$touch()
        this.$nextTick(() => this.findFirstError())
        return this.isValid
      },

      register() {
        let data = {
          registrationNumber: this.form.registrationNumber,
          email: this.form.email,
          password: this.form.password
        }
        this.$store.dispatch('register', data)
          .then(() => this.confirmationModal = true)
          .catch(err => {
            this.form.password = ''
            this.form.confirmPassword = ''
            this.registerError = true
            this.registerErrorText = err.response.data.message
            console.log(err.response.data.message)
          })
      },

      redirectToDashboard() {
        this.$router.push('/dashboard')
      }
    }
  }
</script>

<style scoped>
  .btn.disabled {
    cursor: auto;
  }
  .errorColor {
    color: red;
  }
</style>
