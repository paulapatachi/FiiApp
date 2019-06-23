<template>
  <b-row>
    <b-col sm="6">
      <b-card>
        <h3> Number of attendances =  5</h3>
        <h3> First homework grade = 4.53  </h3>
        </br>
        <button @click="getECTSPred()">ECTSPrediction</button>
        <h2 v-if="prediction != null">{{ prediction }}</h2>

      </b-card>
    </b-col>
  </b-row>
</template>

<script>
  import axios from 'axios'

export default {
    name: 'SendEmail',
    props: {
      username: {
        type: String,
        default: 'UserName'
      },
      password: {
        type: String,
        default: 'Password'
      },
    },
    data() {
      return {
        prediction: null
      }
    },
    methods: {
      getECTSPred() {
        let url = document.getElementById('axiosUrls').getAttribute('data-ECTSPredictionUrl')
        axios.get(url)
          .then(response => {
            this.$data.prediction = response.data
          })
      },
    }
}
</script>
