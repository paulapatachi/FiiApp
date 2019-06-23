<template>
  <div class="animated fadeIn">
    <b-card>
      <b-row>
        <b-col>
          <h4 id="traffic" class="card-title mb-0">Averages Graphic Per Semester For My Class</h4>
        </b-col>
      </b-row>
      <statistics-chart chartId="main-chart-01" class="chart-wrapper" style="height:500px;margin-top:40px;" height="500"></statistics-chart>
      <div slot="footer" v-if="numberOfGrades">
        <b-row class="text-center">
          <b-col class="mb-sm-2 mb-0">
            <div class="text-muted">Value = 10</div>
            <strong>{{ numberOfGrades[5].number }} Grades ({{ numberOfGrades[5].percent }}%)</strong>
          </b-col>
          <b-col class="mb-sm-2 mb-0 d-md-down-none">
            <div class="text-muted">Value = 9</div>
            <strong>{{ numberOfGrades[4].number }} Grades ({{ numberOfGrades[4].percent }}%)</strong>
          </b-col>
          <b-col class="mb-sm-2 mb-0">
            <div class="text-muted">Value = 8</div>
            <strong>{{ numberOfGrades[3].number }} Grades ({{ numberOfGrades[3].percent }}%)</strong>
          </b-col>
          <b-col class="mb-sm-2 mb-0">
            <div class="text-muted">Value = 7</div>
            <strong>{{ numberOfGrades[2].number }} Grades ({{ numberOfGrades[2].percent }}%)</strong>
          </b-col>
          <b-col class="mb-sm-2 mb-0 d-md-down-none">
            <div class="text-muted">Value = 6</div>
            <strong>{{ numberOfGrades[1].number }} Grades ({{ numberOfGrades[1].percent }}%)</strong>
          </b-col>
          <b-col class="mb-sm-2 mb-0 d-md-down-none">
            <div class="text-muted">Value = 5</div>
            <strong>{{ numberOfGrades[0].number }} Grades ({{ numberOfGrades[0].percent }}%)</strong>
          </b-col>
        </b-row>
          <b-progress show-progress class="mb-3">
            <b-progress-bar :precision="2" variant="success" :value="numberOfGrades[5].number"></b-progress-bar>
            <b-progress-bar :precision="2" variant="info" :value="numberOfGrades[4].number"></b-progress-bar>
            <b-progress-bar :precision="2" variant="warning" :value="numberOfGrades[3].number"></b-progress-bar>
            <b-progress-bar :precision="2" variant="danger" :value="numberOfGrades[2].number"></b-progress-bar>
            <b-progress-bar :precision="2" variant="secondary" :value="numberOfGrades[1].number"></b-progress-bar>
            <b-progress-bar :precision="2" :value="numberOfGrades[0].number"></b-progress-bar>
          </b-progress>
      </div>
    </b-card>
  </div>
</template>

<script>
import StatisticsChart from './student/Statistics'
  import axios from 'axios'

export default {
  name: 'dashboard',
  components: {
    StatisticsChart,
  },
  data: function () {
    return {
      numberOfGrades: null
    }
    },
    mounted() {
      this.getNumberOfGrades()
    },
  methods: {
    getNumberOfGrades() {
      let url = document.getElementById('axiosUrls').getAttribute('data-numberOfGradesUrl')
      axios.get(url)
        .then(response => {
          this.numberOfGrades = response.data
        })
    },

  }
}
</script>

<style>

</style>
