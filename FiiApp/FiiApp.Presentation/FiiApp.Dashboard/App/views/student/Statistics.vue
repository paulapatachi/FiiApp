<script>
import { Line } from 'vue-chartjs'
import { getStyle, hexToRgba } from '@coreui/coreui/dist/js/coreui-utilities'
import { CustomTooltips } from '@coreui/coreui-plugin-chartjs-custom-tooltips'
import { random } from '@/shared/utils'
  import axios from 'axios'

  export default {
    extends: Line,
    props: ['height'],
    data() {
      return {
        statisticsDataSet: null,
        currentUserData: null,
        valuesForChart: []
      }
    },
    mounted() {
      this.getGradesForCurrentUser()
      
    },
      methods: {
        getStatistics() {
          let url = document.getElementById('axiosUrls').getAttribute('data-gradesPerSemesterUrl')
          axios.get(url)
            .then(response => {
              this.statisticsDataSet = response.data
              this.fillChartWithData()
            })

        },

        getGradesForCurrentUser() {
          let url = document.getElementById('axiosUrls').getAttribute('data-currentUserGradesPerSemesterUrl')
          axios.get(url)
            .then(response => {
              this.currentUserData = response.data
              this.getStatistics()
            })
        },

        formatDataSetInput(element) {
          var values = Object.values(element)
          var entry = {
            label: 'Dataset',
            backgroundColor: 'transparent',
            borderColor: '#' + ((1 << 24) * Math.random() | 0).toString(16),
            pointHoverBackgroundColor: '#fff',
            borderWidth: 2,
            data: values
          }
          this.valuesForChart.push(entry)
        },

        fillChartWithData() {
          var currentEntry = {
            label: 'My average',
            backgroundColor: 'transparent',
            borderColor: '#000000',
            pointHoverBackgroundColor: '#fff',
            borderWidth: 6,
            data: Object.values(this.currentUserData)
          }
          this.valuesForChart.push(currentEntry)
          this.statisticsDataSet.forEach(this.formatDataSetInput)


          this.renderChart({
            labels: ['Semester1', 'Semester2', 'Semester3', 'Semester4', 'Semester5', 'Semester6'],
            datasets: this.valuesForChart
          }, {
              tooltips: {
                enabled: false,
                custom: CustomTooltips,
                intersect: true,
                mode: 'index',
                position: 'nearest',
                callbacks: {
                  labelColor: function (tooltipItem, chart) {
                    return { backgroundColor: chart.data.datasets[tooltipItem.datasetIndex].borderColor }
                  }
                }
              },
              maintainAspectRatio: false,
              legend: {
                display: false
              },
              scales: {
                xAxes: [{
                  gridLines: {
                    drawOnChartArea: false
                  }
                }],
                yAxes: [{
                  ticks: {
                    min: 5,
                    max: 10,
                    stepSize: 0.5
                  },
                  gridLines: {
                    display: true
                  }
                }]
              },
              elements: {
                point: {
                  radius: 0,
                  hitRadius: 10,
                  hoverRadius: 4,
                  hoverBorderWidth: 3
                }
              }
            })
        }
      }
  }
</script>
