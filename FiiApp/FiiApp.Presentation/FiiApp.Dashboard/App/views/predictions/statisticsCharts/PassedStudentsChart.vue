<script>
import { Pie } from 'vue-chartjs'
  import axios from 'axios'

  export default {
    extends: Pie,
    props: {
      passedChart: {
        type: Boolean,
        required: true
      }
    },
    data() {
      return {
        passedStudentsDataSet: null
      }
    },
    mounted() {
      this.getPassedStudentsStatistics()
    },
    watch: {
      passedStudentsDataSet() {
        var studyYears = this.passedStudentsDataSet.map(obj => obj.year)
        var passedResults = this.passedStudentsDataSet.map(obj => obj.passed)
        var unpassedResults = this.passedStudentsDataSet.map(obj => obj.unpassed)

        var chartData = null
        if (this.passedChart === true) {
          chartData = passedResults
        } else {
          chartData = unpassedResults
        }

      this.renderChart({
        labels: studyYears,
        datasets: [
          {
            backgroundColor: [
              '#00bc16',
              '#04def2',
              '#ed0000',
              '#b50cb2',
              '#a2d30e',
              '#1d05ba',
              '#ff8300',
              '#DD1B89',
            ],
            data: chartData
          }
        ]
      }, { responsive: true, maintainAspectRatio: true })
    }
  },

    methods: {
      getPassedStudentsStatistics() {
        let url = document.getElementById('axiosUrls').getAttribute('data-PassedStudentsStatisticsUrl')
        axios.get(url)
          .then(response => {
            this.passedStudentsDataSet = response.data
          })
      },
    }
}
</script>
