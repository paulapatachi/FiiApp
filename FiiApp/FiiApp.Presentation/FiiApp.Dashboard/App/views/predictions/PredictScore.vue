<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col md="6">
        <b-card header-bg-variant="primary">
          <div slot="header">
            <strong>Mathematics</strong>
          </div>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="Gender">Gender</label>
            </b-col>
            <b-col>
              <label class="mr-4">
                <input type="radio" v-model="math.Gender" value="0" /> Male
              </label>
              <label>
                <input type="radio" v-model="math.Gender" value="1" /> Female
              </label>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="Class">Class</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-select v-model="group" :options="['A', 'B']">
                  </b-form-select>
                </b-col>
                <b-col>
                  <b-form-select v-model="groupNumber" :options="[1, 2, 3, 4, 5, 6, 7]">
                  </b-form-select>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="Class">Special Bonus</label>
            </b-col>
            <b-col>
              <b-form-input placeholder="0" type="text" v-model="math.BS"></b-form-input>
            </b-col>
          </b-row>

          <b-row>
            <b-col sm="5">
              <label class="color-gray">Semester</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <label placeholder="0" class="color-gray">First Part</label>
                </b-col>
                <b-col>
                  <label placeholder="0" class="color-gray">Second Part</label>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NrPS">Seminar Attendance</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPS1" min="0" max="7"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPS2" min="0" max="7"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NrPSM">Meritorious Participation in the Seminar</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPSM1" min="0" max="7"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPSM2" min="0" max="7"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NrPSA">Active Participation in the Seminar</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPSA1" min="0" max="7"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPSA2" min="0" max="7"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NrPC">Consultations Attendance</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPC1" min="0" max="7"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPC2" min="0" max="7"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NrPCA">Active Participation in Consultations</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPCA1" min="0" max="7"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="number" v-model="math.NrPCA2" min="0" max="7"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NET">Homework Score</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="text" v-model="math.NET1"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="text" v-model="math.NET2"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>

          <b-row class="mb-1">
            <b-col sm="5">
              <label for="NL">Exam Score</label>
            </b-col>
            <b-col>
              <b-row>
                <b-col>
                  <b-form-input placeholder="0" type="text" v-model="math.NL1"></b-form-input>
                </b-col>
                <b-col>
                  <b-form-input placeholder="0" type="text" v-model="math.NL2"></b-form-input>
                </b-col>
              </b-row>
            </b-col>
          </b-row>
          <b-row class="pl-5 py-3">
            <b-col sm="5">
              <b-button variant="primary" @click="getScorePrediction()">Predict my score</b-button>
            </b-col>
            <b-col v-if="scorePrediction">
              <b-button @click="getECTSPrediction()" class="rainbow-button">Are you curious to find your grade?</b-button>
            </b-col>
          </b-row>

          <b-row v-if="scorePrediction != null" class="px-5">
            <b-card bg-variant="primary" border-variant="primary">
              <b-row>
                <h4>According to your filled data for math, the final score estimated by machine learning service is . . .</h4>
                <h3 class="pl-5">{{ scorePrediction }} </h3>
                <h3 v-if="gradePrediction">&nbsp;≈&nbsp;{{ gradePrediction }}</h3>
              </b-row>
            </b-card>
          </b-row>

        </b-card>
      </b-col>
    </b-row>
    
  </div>
</template>
<script>
  import axios from 'axios'
  export default {
    name: 'predictScore',
    data() {
      return {
        selected: '',
        scorePrediction: null,
        gradePrediction: null,
        group: "A",
        groupNumber: 1,
        math: {
          Gender: 0,
          Class: null,
          NrPS1: null,
          NrPSM1: null,
          NrPSA1: null,
          NrPCA1: null,
          NrPC1: null,
          NET1: null,
          NL1: null,
          NrPS2: null,
          NrPSM2: null,
          NrPSA2: null,
          NrPCA2: null,
          NrPC2: null,
          NET2: null,
          NL2: null,
          BS: null
        },
      }
    },
    methods: {
      getScorePrediction() {
        this.gradePrediction = null
        if (this.$data.group === "A") {
          this.$data.math.Class = this.$data.groupNumber
        } else {
          this.$data.math.Class = 7 + this.$data.groupNumber
        }

        if (this.math.NET1) this.math.NET1 = this.math.NET1.replace(/,/g, '.')
        if (this.math.NET2) this.math.NET2 = this.math.NET2.replace(/,/g, '.')
        if (this.math.NL1) this.math.NL1 = this.math.NL1.replace(/,/g, '.')
        if (this.math.NL2) this.math.NL2 = this.math.NL2.replace(/,/g, '.')
        if (this.math.BS) this.math.BS = this.math.BS.replace(/,/g, '.')

        let url = document.getElementById('axiosUrls').getAttribute('data-PFPredictionUrl')
        axios.post(url, JSON.stringify(this.math), {
          headers: {
            'Content-type': 'application/json'
          }
        })
          .then(response => {
            this.$data.scorePrediction = response.data
          })
      },
      getECTSPrediction() {
        let url = document.getElementById('axiosUrls').getAttribute('data-ECTSPredictionUrl')
        if (this.scorePrediction === null) {
          this.scorePrediction = 0
        }
        var score = this.scorePrediction.replace(/,/g, '.')
        axios.get(url, { params: { PFScore: score } })
          .then(response => {
            this.$data.gradePrediction = response.data
          })
      },
    }
  }
</script>
<style>
  .color-gray {
    color: lightgray;
  }

  .rainbow-button {
    background-image: linear-gradient(90deg, #00C0FF 0%, #FFCF00 49%, #FC4F4F 80%, #00C0FF 100%);
    animation: slidebg 2s linear infinite;
  }

  @keyframes slidebg {
    to {
      background-position: 32vw;
    }
  }

</style>
