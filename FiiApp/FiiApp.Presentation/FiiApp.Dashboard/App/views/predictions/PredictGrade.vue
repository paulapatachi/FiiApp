<template>
  <b-row>
    <b-col lg="6">
      <b-card header-bg-variant="primary">
        <div slot="header">
          <strong>Mathematics</strong>
        </div>

        <b-row class="mb-1">
          <b-col sm="5">
            <label for="NrPS">Your score</label>
          </b-col>
          <b-col>
            <b-form-input placeholder="0" typeof="text" v-model="score"></b-form-input>
          </b-col>
        </b-row>

        <b-row class="pl-5 py-3">
          <b-button variant="primary" @click="getECTSPrediction()">Predict my grade</b-button>
        </b-row>

        <b-row v-if="prediction != null" class="px-5">
          <b-card bg-variant="primary" border-variant="primary">
            <b-row>
              <h4>According to your score at math, the grade estimated by machine learning service is . . . </h4>
              <h3 class="pl-5">{{ prediction }}</h3>
            </b-row>
          </b-card>
        </b-row>

      </b-card>
    </b-col>
  </b-row>
</template>

<script>
  import axios from 'axios'

export default {
    name: 'predictGrade',
    data() {
      return {
        prediction: null,
        score: null
      }
    },
    methods: {
      getECTSPrediction() {
        let url = document.getElementById('axiosUrls').getAttribute('data-ECTSPredictionUrl')
        if (this.score === null) {
          this.score = 0
        }
        axios.get(url, { params: { PFScore: this.score } })
          .then(response => {
            this.$data.prediction = response.data
          })
      },
    }
}
</script>
