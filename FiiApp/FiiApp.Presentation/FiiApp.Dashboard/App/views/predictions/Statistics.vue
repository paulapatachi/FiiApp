<template>
  <div class="animated fadeIn">
    <b-card header="Gender Chart">
      <div class="chart-wrapper">
        <gender-chart chartId="chart-bar-gender" />
      </div>
    </b-card>

    <b-card header="Attendance Chart">
      <div class="chart-wrapper">
        <attendance-chart chartId="chart-bar-attendance" />
      </div>
    </b-card>

    <b-card header="Seminar And Consultations Activity Chart">
      <div class="chart-wrapper">
        <seminar-activity-chart chartId="chart-bar-seminar-activity" />
      </div>
    </b-card>

    <b-card>
      <b-row class="pb-2">
        <b-col sm="6">
          <b-col>
            <h4 id="finalScore" class="card-title mb-0">Final Score</h4>
          </b-col>
          <b-col v-if="selected === 'Gender'">
            <b-button-group class="mr-3">
              <b-button class="maxMale"></b-button>
              <b-button class="averageMale"></b-button>
              <b-button class="minMale"></b-button>
              Male
            </b-button-group>
            <b-button-group>
              <b-button class="maxFemale"></b-button>
              <b-button class="averageFemale"></b-button>
              <b-button class="minFemale"></b-button>
              Female
            </b-button-group>
          </b-col>
        </b-col>

        <b-col sm="6" class="d-none d-md-block">
          <b-button-toolbar class="float-right" aria-label="Toolbar with buttons group">
            <b-form-radio-group class="mr-3" id="radiosBtn" buttons button-variant="outline-secondary" v-model="selected" name="radiosBtn">
              <b-form-radio class="mx-0" value="Year">Year</b-form-radio>
              <b-form-radio class="mx-0" value="Class">Class</b-form-radio>
              <b-form-radio class="mx-0" value="Gender">Gender</b-form-radio>
            </b-form-radio-group>
          </b-button-toolbar>
        </b-col>
      </b-row>
      <div class="chart-wrapper">
        <final-score-chart :selected="selected" chartId="main-chart-final-score"></final-score-chart>
      </div>
    </b-card>

    <b-card-group deck>
      <b-card header="Passed Students Chart">
        <div class="chart-wrapper">
          <passed-students-chart :passedChart="true" chartId="chart-bar-pass" />
        </div>
      </b-card>

      <b-card header="Unpassed Students Chart">
        <div class="chart-wrapper">
          <passed-students-chart :passedChart="false" chartId="chart-bar-unpass" />
        </div>
      </b-card>
    </b-card-group>
  </div>
</template>

<script>
  import axios from 'axios'
  import GenderChart from './statisticsCharts/GenderChart'
  import AttendanceChart from './statisticsCharts/AttendanceChart'
  import FinalScoreChart from './statisticsCharts/FinalScoreChart'
  import SeminarActivityChart from './statisticsCharts/SeminarActivityChart'
  import PassedStudentsChart from './statisticsCharts/PassedStudentsChart'

export default {
    name: 'Statistics',
    components: {
      GenderChart,
      AttendanceChart,
      FinalScoreChart,
      SeminarActivityChart,
      PassedStudentsChart
    },
    data() {
      return {
        selected: 'Year',
     
      }
    },
    mounted() {
    },
    methods: {
    },
}
</script>
<style>
  .maxMale {
    background-color: #0a19b5;
  }

  .averageMale {
    background-color: #10a01a !important;
  }

  .minMale {
    background-color: #c60505;
  }

  .maxFemale {
    background-color: #1df9f9;
  }

  .averageFemale {
    background-color: #b7f900;
  }

  .minFemale {
    background-color: #f9a31b;
  }
</style>
