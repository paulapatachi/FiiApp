<!--<template>
  <b-row>
    <b-col sm="6">
      <b-card>
        <div slot="header">
          <strong>Send Email </strong><small>Form</small>
        </div>
        <b-form-group>
          <label for="toEmail">To</label>
          <b-form-input type="text" id="toEmail" placeholder="Enter the email"></b-form-input>
        </b-form-group>
        <b-form-group>
          <label for="ccEmail">Cc</label>
          <b-form-input type="text" id="ccEmail" placeholder="Cc emails"></b-form-input>
        </b-form-group>
        <b-form-group>
          <label for="subject">Subject</label>
          <b-form-input type="text" id="subject" placeholder="Enter email subject"></b-form-input>
        </b-form-group>
        <b-form-group>
          <label for="body">body</label>
          <b-form-textarea id="body"
                           v-model="text"
                           placeholder="Your body..."
                           rows="3"
                           max-rows="6"></b-form-textarea>
        </b-form-group>

        <div slot="footer">
          <b-button type="submit" size="sm" variant="primary"><i class="fa fa-dot-circle-o"></i> Send</b-button>
        </div>
      </b-card>
    </b-col>
  </b-row>
</template>

<script>
export default {
    name: 'SendEmail',
    data() {
      return {
        selected: [], // Must be an array reference!
        show: true,
        text: null
      }
    },
    methods: {
      click() {
        // do nothing
      }
    }
}
</script>-->




<template>
      <b-card class="mb-3">
        <p class="text-center">New message</p>
        <form>
          <div class="form-row mb-3">
            <label for="to" class="col-2 col-sm-1 col-form-label">To:</label>
            <b-col cols="12" sm="11">
              <input v-model="email.toemail" type="email" class="form-control" id="to" placeholder="Type email">
            </b-col>
          </div>
          <div class="form-row mb-3">
            <label for="cc" class="col-2 col-sm-1 col-form-label">CC:</label>
            <b-col cols="12" sm="11">
              <input v-model="email.ccemail" type="email" class="form-control" id="cc" placeholder="Type email">
            </b-col>
          </div>
          <div class="form-row mb-3">
            <label for="subject" class="col-2 col-sm-1 col-form-label">Subject:</label>
            <b-col cols="12" sm="11">
              <input v-model="email.subject" type="text" class="form-control" id="subject" placeholder="Type subject">
            </b-col>
          </div>
        </form>
        <b-row>
          <b-col sm="11" class="ml-auto">
            <div class="toolbar" role="toolbar">
              <div class="btn-group mr-1">
                <b-button variant="light"><span class="fa fa-bold"></span></b-button>
                <b-button variant="light"><span class="fa fa-italic"></span></b-button>
                <b-button variant="light"><span class="fa fa-underline"></span></b-button>
              </div>
              <div class="btn-group mr-1">
                <b-button variant="light"><span class="fa fa-align-left"></span></b-button>
                <b-button variant="light"><span class="fa fa-align-right"></span></b-button>
                <b-button variant="light"><span class="fa fa-align-center"></span></b-button>
                <b-button variant="light"><span class="fa fa-align-justify"></span></b-button>
              </div>
              <div class="btn-group mr-1">
                <b-button variant="light"><span class="fa fa-indent"></span></b-button>
                <b-button variant="light"><span class="fa fa-outdent"></span></b-button>
              </div>
              <div class="btn-group mr-1">
                <b-button variant="light"><span class="fa fa-list-ul"></span></b-button>
                <b-button variant="light"><span class="fa fa-list-ol"></span></b-button>
              </div>
              <b-button variant="light" class="mr-1"><span class="fa fa-trash-o"></span></b-button>
              <b-button variant="light"><span class="fa fa-paperclip"></span></b-button>
              <b-dropdown variant="light" class="ml-1">
                <template slot="button-content">
                  <span class="fa fa-tags"></span>
                </template>
                <b-dropdown-item href="#">add label <b-badge variant="danger"> Home</b-badge></b-dropdown-item>
                <b-dropdown-item href="#">add label <b-badge variant="info"> Job</b-badge></b-dropdown-item>
                <b-dropdown-item href="#">add label <b-badge variant="success"> Clients</b-badge></b-dropdown-item>
                <b-dropdown-item href="#">add label <b-badge variant="warning"> News</b-badge></b-dropdown-item>
              </b-dropdown>
            </div>
            <div class="form-group mt-4">
              <textarea v-model="email.body" class="form-control" id="body" name="body" rows="12" placeholder="Click here to reply"></textarea>
            </div>
            <div class="form-group">
              <b-button class="mr-1" type="submit" variant="primary" @click.prevent="sendEmail">
                <i v-if="buttonLoading" class="fa fa-spinner fa-spin"></i>
                <span v-else>Send</span>
              </b-button>
            </div>
          </b-col>
        </b-row>
      </b-card>
</template>
<script>
  import axios from 'axios'

  import Vue from 'vue'
  import VueNotifications from 'vue-notifications'
  import miniToastr from 'mini-toastr'// https://github.com/se-panfilov/mini-toastr

  const toastTypes = {
    success: 'success',
    error: 'error',
    info: 'info',
    warn: 'warn'
  }

  miniToastr.init({ types: toastTypes })

  function toast({ title, message, type, timeout, cb }) {
    return miniToastr[type](message, title, timeout, cb)
  }

  const options = {
    success: toast,
    error: toast,
    info: toast,
    warn: toast
  }
  //  VueNotifications.setPluginOptions(options)

  Vue.use(VueNotifications, options)

  export default {
    name: 'compose',
    data() {
      return {
        email: {
          toemail: null,
          ccemail: null,
          subject: null,
          body: null
        },
        buttonLoading: null
      }
    },

    notifications: {
      showSuccessMsg: {
        type: VueNotifications.types.success,
        title: 'Hello there',
        message: 'Message was sent'
      },
      showInfoMsg: {
        type: VueNotifications.types.info,
        title: 'Hey you',
        message: 'Here is some info for you'
      },
      showWarnMsg: {
        type: VueNotifications.types.warn,
        title: 'Wow, man',
        message: 'That\'s the kind of warning'
      },
      showErrorMsg: {
        type: VueNotifications.types.error,
        title: 'Error',
        message: 'Message was not sent'
      }
    },

    methods: {
      splitEmail(emails) {
        if (emails && emails.length > 0) {
          return emails.split(' ')
        }
        return emails
      },

      sendEmail() {
        this.buttonLoading = true
        let url = document.getElementById('axiosUrls').getAttribute('data-sendEmailUrl')
        let emailModel = {
          toemail: this.splitEmail(this.email.toemail),
          ccemail: this.splitEmail(this.email.ccemail),
          subject: this.email.subject,
          body: this.email.body
        }
        axios.post(url, emailModel, { headers: { 'Content-Type': 'application/json' } })
          .then(() => {
            this.showSuccessMsg()
          })
          .catch(() => {
            this.showErrorMsg()
          })
          .finally(() => {
            this.email = {}
            this.buttonLoading = false
          })
      }
    }
  }
</script>
