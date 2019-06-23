<script>
import { Bar } from 'vue-chartjs'
import { CustomTooltips } from '@coreui/coreui-plugin-chartjs-custom-tooltips'
  import axios from 'axios'
export default {
    extends: Bar,
    props: {
    },
    data() {
      return {
        genderDataSet: null
      }
    },
    mounted() {
      this.getGenderStatistics()
    },
    watch: {
      genderDataSet() {
        // Overwriting base render method with actual data.

        var studyYears = this.genderDataSet.map(obj => obj.year)
        var maleResults = this.genderDataSet.map(obj => obj.male)
        var femaleResults = this.genderDataSet.map(obj => obj.female)
        var totalResults = this.genderDataSet.map(obj => obj.total)

        this.renderChart(
          {
            labels: studyYears,
            datasets: [
              {
                label: 'Male Students',
                backgroundColor: '#1864dd',
                data: maleResults
              },
              {
                label: 'Female Students',
                backgroundColor: '#e80909',
                data: femaleResults
              }
            ]
          },
          {
            responsive: true,
            maintainAspectRatio: false,
            tooltips: {
              enabled: false,
              custom: CustomTooltips,
              intersect: true,
              mode: 'index',
              position: 'nearest',
              callbacks: {
                labelColor: function (tooltipItem, chart) {
                  return { backgroundColor: chart.data.datasets[tooltipItem.datasetIndex].backgroundColor }
                }
              }
            }
          }
        )
      }
    },
    methods: {
      getGenderStatistics() {
        let url = document.getElementById('axiosUrls').getAttribute('data-genderStatisticsUrl')
        axios.get(url)
          .then(response => {
            this.genderDataSet = response.data
          })
      },
    }
}
</script>
