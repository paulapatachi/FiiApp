<template>
  <div>
    <b-col sm="9">
      <b-card border-variant="primary">
        <!--<div slot="header">
          <strong>Profile</strong>
        </div>-->
        <b-row class="mb-1">
          <b-col sm="3">
            <label for="firstName">First Name</label>
          </b-col>
          <b-col>
            <b-form-input readonly type="text" id="firstName" v-model="teacherInfo.firstName"></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1">
          <b-col sm="3">
            <label for="lastName">Last Name</label>
          </b-col>
          <b-col>
            <b-form-input readonly type="text" id="lastName" v-model="teacherInfo.lastName"></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1" v-if="teacherInfo.rank">
          <b-col sm="3">
            <label for="rank">Rank</label>
          </b-col>
          <b-col>
            <b-form-input readonly type="text" id="rank" v-model="teacherInfo.rank"></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1" v-if="teacherInfo.office">
          <b-col sm="3">
            <label for="office">Office</label>
          </b-col>
          <b-col>
            <b-form-input readonly type="text" id="office" v-model="teacherInfo.office"></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1" v-if="teacherInfo.email">
          <b-col sm="3">
            <label for="email">Email</label>
          </b-col>
          <b-col>
            <b-form-input readonly type="text" id="email" v-model="teacherInfo.email"></b-form-input>
          </b-col>
        </b-row>
        <b-row class="mb-1" v-if="teacherInfo.webAddress">
          <b-col sm="3">
            <label for="webAddress">Web Address</label>
          </b-col>
          <b-col>
            <b-link class="clickPointer" :href="teacherInfo.webAddress"><b-form-input readonly type="text" id="webAddress" v-model="teacherInfo.webAddress"></b-form-input></b-link>
          </b-col>
        </b-row>
        <b-row class="mb-1" v-if="teacherInfo.areasOfInterest">
          <b-col sm="3">
            <label for="areasOfInterest">Areas Of Interest</label>
          </b-col>
          <b-col>
            <b-form-textarea readonly type="text" id="areasOfInterest" v-model="teacherInfo.areasOfInterest" rows="2" no-resize></b-form-textarea>
          </b-col>
        </b-row>
      </b-card>
    </b-col>
  </div>
</template>

<script>
  import axios from 'axios'

  export default {
    name: 'c-table',
    inheritAttrs: false,
    props: {
      teacherInfo: {
        type: Object,
        required: false
      }
    },
    data: () => {
      return {
        types: [
          'text',
          'password',
          'email',
          'number',
          'url',
          'tel',
          'date',
          `time`,
          'range',
          'color'
        ]
      }
    },
    methods: {
    }
  }
</script>
<style>
  .clickPointer input {
    cursor: pointer;
  }
</style>


