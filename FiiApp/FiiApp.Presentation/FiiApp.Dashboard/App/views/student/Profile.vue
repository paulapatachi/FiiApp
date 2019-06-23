<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="7">
        <b-card header-bg-variant="primary">
          <div slot="header">
            <strong>Profile</strong>
          </div>
          <b-row>
            <b-col sm="7">
              <b-form-group>
                <label for="university">University</label>
                <b-form-input readonly type="text" id="university" v-model="university"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="5">
              <b-form-group>
                <label for="faculty">Faculty</label>
                <b-form-input readonly type="text" id="faculty" v-model="faculty"></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
          <b-row>
            <b-col sm="5">
              <b-form-group>
                <label for="firstName">First Name</label>
                <b-form-input readonly type="text" id="firstName" v-model="user.firstName"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="2">
              <b-form-group>
                <label for="fatherInitials">Father Initials</label>
                <b-form-input readonly type="text" id="fatherInitials" v-model="user.fatherInitials"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="5">
              <b-form-group>
                <label for="lastName">Last Name</label>
                <b-form-input readonly type="text" id="lastName" v-model="user.lastName"></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
          <b-row>
            <b-col sm="4">
              <b-form-group>
                <label for="registrationNumber">Registration Number</label>
                <b-form-input readonly type="text" id="registrationNumber" v-model="user.registrationNumber"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="4">
              <b-form-group>
                <label for="email">Email</label>
                <b-form-input readonly type="text" id="email" v-model="user.email"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="4">
              <b-form-group>
                <label for="phoneNumber">Phone Number</label>
                <b-form-input readonly type="text" id="phoneNumber" v-model="user.phoneNumber"></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
          <b-row>
            <b-col sm="4">
              <b-form-group>
                <label for="dateOfBirth">Date Of Birth</label>
                <b-form-input readonly type="text" id="dateOfBirth" v-model="user.dateOfBirth"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="4">
              <b-form-group>
                <label for="nationality">Nationality</label>
                <b-form-input readonly type="text" id="nationality" v-model="user.nationality"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col sm="4">
              <b-form-group>
                <label for="citizenship">Citizenship</label>
                <b-form-input readonly type="text" id="citizenship" v-model="user.citizenship"></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
          <b-form-group>
            <label for="address">Address</label>
            <b-form-input readonly type="text" id="address" v-model="user.address"></b-form-input>
          </b-form-group>
        </b-card>
      </b-col>
      <b-col sm="5">
        <b-card>
          <b-img class="mb-3" center width="124" height="124" rounded="circle" thumbnail src="img/profilePic.jpg" alt="Image 1"></b-img>
          <h4 class="text-center">{{ user.firstName }} {{ user.lastName }}</h4>
          <h6 class="text-center">Current study year: {{ user.studyYear }}</h6>
          <h6 class="text-center">Class: {{ user.class }}</h6>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
  name: 'profile',
  data () {
    return {
      selected: [], // Must be an array reference!
      show: true,
      //user: {
      //  address: "Stefanesti, jud. Botosani",
      //  citizenship: "Romanian",
      //  dateOfBirth: "28/02/1997",
      //  email: "paula.patachi@info.uaic.ro",
      //  fatherInitials: "D.",
      //  firstName: "Paula",
      //  lastName: "Patachi",
      //  nationality: "Romanian",
      //  phoneNumber: "0764679764",
      //  registrationNumber: "31090104SL151262",
      //  class: "B6",
      //  studyYear: 3
      //}
      user: {
        address: null,
        citizenship: null,
        dateOfBirth: null,
        email: null,
        fatherInitials: null,
        firstName: null,
        lastName: null,
        nationality: null,
        phoneNumber: null,
        registrationNumber: null,
        class: null,
        studyYear: null
      },
      university: "“Alexandru Ioan Cuza” University of Iasi",
      faculty: "Faculty of Computer Science"
    }
  },
  beforeMount() {
    this.getUserInfo()
  },
  methods: {
    getUserInfo() {
      let url = document.getElementById('axiosUrls').getAttribute('data-userInfoUrl')
      axios.get(url)
        .then(response => {
          this.user = response.data
        })
    },

    
  }
}
</script>
