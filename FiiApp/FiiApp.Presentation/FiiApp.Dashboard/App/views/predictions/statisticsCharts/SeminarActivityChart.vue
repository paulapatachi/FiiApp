<script>
import { Line } from 'vue-chartjs'
import { CustomTooltips } from '@coreui/coreui-plugin-chartjs-custom-tooltips'
import { hexToRgba } from '@coreui/coreui/dist/js/coreui-utilities'
  import axios from 'axios'

export default {
  components: {
    hexToRgba,
    CustomTooltips
  },
    extends: Line,
    data() {
      return {
        seminarActivityDataSet: null
      }
    },
  mounted() {
      this.getSeminarActivityStatistics()
    },
    watch: {
      seminarActivityDataSet() {

        var studyYears = this.seminarActivityDataSet.map(obj => obj.year)
        var meritoriousSeminar = this.seminarActivityDataSet.map(obj => obj.meritoriousSeminar)
        var activeSeminar = this.seminarActivityDataSet.map(obj => obj.activeSeminar)
        var activeConsultation = this.seminarActivityDataSet.map(obj => obj.activeConsultation)

        this.renderChart(
          {
            labels: studyYears,
            datasets: [
              {
                label: 'Active Consultation',
                backgroundColor: hexToRgba('#7a0b78', 70),
                data: activeConsultation
              },
              {
                label: 'Active Seminar',
                backgroundColor: hexToRgba('#19cc0c', 70),
                data: activeSeminar
              },
              {
                label: 'Meritorious Seminar',
                backgroundColor: hexToRgba('#19fff3', 70),
                data: meritoriousSeminar
              },
              
              
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
      getSeminarActivityStatistics() {
        let url = document.getElementById('axiosUrls').getAttribute('data-seminarActivityStatisticsUrl')
        axios.get(url)
          .then(response => {
            this.seminarActivityDataSet = response.data
          })
      },
    }
}
</script>
