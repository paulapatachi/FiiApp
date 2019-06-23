<script>
  import { Line } from 'vue-chartjs'
  import { getStyle, hexToRgba } from '@coreui/coreui/dist/js/coreui-utilities'
  import { CustomTooltips } from '@coreui/coreui-plugin-chartjs-custom-tooltips'
  import { random } from '@/shared/utils'
  import axios from 'axios'

  export default {
    extends: Line,
    props: {
      selected: {
        type: String,
        required: true
      }
    },
    data() {
      return {
        finalScoreDataSet: null,
        labelList: null
      }
    },
    mounted() {
      this.getFinalScoreStatisticsByYear()
    },

    watch: {
      selected() {
        if (this.selected === 'Year') {
          this.getFinalScoreStatisticsByYear()
        } else if (this.selected === 'Class') {
          this.getFinalScoreStatisticsByClass()
        } else if(this.selected === 'Gender') {
          this.getFinalScoreStatisticsByGender()
        }
      },
      finalScoreDataSet() {
        if (this.selected === 'Year') {
          this.displayChartForYearOrClass()
        } else if (this.selected === 'Class') {
          this.displayChartForYearOrClass()
        } else if (this.selected === 'Gender') {
          this.displayChartForGender()
        }
        
      }
    },

      methods: {
        getFinalScoreStatisticsByYear() {
          let url = document.getElementById('axiosUrls').getAttribute('data-finalScoreStatisticsByYearUrl')
          axios.get(url)
            .then(response => {
              this.finalScoreDataSet = response.data
            })
        },

        getFinalScoreStatisticsByClass() {
          let url = document.getElementById('axiosUrls').getAttribute('data-finalScoreStatisticsByClassUrl')
          axios.get(url)
            .then(response => {
              this.finalScoreDataSet = response.data
            })
        },

        getFinalScoreStatisticsByGender() {
          let url = document.getElementById('axiosUrls').getAttribute('data-finalScoreStatisticsByGenderUrl')
          axios.get(url)
            .then(response => {
              this.finalScoreDataSet = response.data
            })
        },

        displayChartForYearOrClass() {
          var studyYears = this.finalScoreDataSet.map(obj => obj.year)
          var classes = this.finalScoreDataSet.map(obj => obj.class)
          var maxScore = this.finalScoreDataSet.map(obj => obj.maxScore)
          var minScore = this.finalScoreDataSet.map(obj => obj.minScore)
          var averageScore = this.finalScoreDataSet.map(obj => obj.averageScore)
          var averagePassScore = this.finalScoreDataSet.map(obj => obj.averagePassScore)

          if (this.selected === 'Year') {
            this.labelList = studyYears
          } else if (this.selected === 'Class') {
            this.labelList = classes
          }

          this.renderChart({
            labels: this.labelList,
            datasets: [
              {
                label: 'Max Score',
                backgroundColor: hexToRgba('#20a8d8', 10),
                borderColor: '#20a8d8',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: maxScore
              },
              {
                label: 'Average Pass Score',
                backgroundColor: 'transparent',
                borderColor: '#9d50e5',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: averagePassScore
              },
              {
                label: 'Average Score',
                backgroundColor: 'transparent',
                borderColor: '#12ea1d',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: averageScore
              },
              {
                label: 'Min Score',
                backgroundColor: 'transparent',
                borderColor: '#f86c6b',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 1,
                borderDash: [8, 5],
                data: minScore
              }
            ]
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
                    beginAtZero: true,
                    stepSize: 20,
                    max: 140
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
        },

        displayChartForGender() {
          var studyYears = this.finalScoreDataSet.map(obj => obj.year)
          
          var maleScore = this.finalScoreDataSet.filter(function (obj) {
            if (obj.gender == 0) {
              return obj
            }
          })

          var femaleScore = this.finalScoreDataSet.filter(function (obj) {
            if (obj.gender == 1) {
              return obj
            }
          })

          var maxScoreMale = maleScore.map(obj => obj.maxScore)
          var minScoreMale = maleScore.map(obj => obj.minScore)
          var averageScoreMale = maleScore.map(obj => obj.averageScore)
          var averagePassScoreMale = maleScore.map(obj => obj.averagePassScore)

          var maxScoreFemale = femaleScore.map(obj => obj.maxScore)
          var minScoreFemale = femaleScore.map(obj => obj.minScore)
          var averageScoreFemale = femaleScore.map(obj => obj.averageScore)
          var averagePassScoreFemale = femaleScore.map(obj => obj.averagePassScore)

          this.renderChart({
            labels: [...new Set(studyYears)],
            datasets: [
              {
                label: 'Max Score Male',
                backgroundColor: hexToRgba('#0a19b5', 10),
                borderColor: '#0a19b5',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: maxScoreMale
              },
              {
                label: 'Max Score Female',
                backgroundColor: hexToRgba('#1df9f9', 10),
                borderColor: '#1df9f9',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: maxScoreFemale
              },
              {
                label: 'Average Pass Score Male',
                backgroundColor: 'transparent',
                borderColor: '#10a01a',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: averagePassScoreMale
              },
              {
                label: 'Average Pass Score Female',
                backgroundColor: 'transparent',
                borderColor: '#b7f900',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 2,
                data: averagePassScoreFemale
              },
              //{
              //  label: 'Average Score Male',
              //  backgroundColor: 'transparent',
              //  borderColor: '#06840f',
              //  pointHoverBackgroundColor: '#fff',
              //  borderWidth: 2,
              //  data: averageScoreMale
              //},
              //{
              //  label: 'Average Score Female',
              //  backgroundColor: 'transparent',
              //  borderColor: '#5eed1c',
              //  pointHoverBackgroundColor: '#fff',
              //  borderWidth: 2,
              //  data: averageScoreFemale
              //},
              {
                label: 'Min Score Male',
                backgroundColor: 'transparent',
                borderColor: '#c60505',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 1,
                borderDash: [8, 5],
                data: minScoreMale
              },
              {
                label: 'Min Score Female',
                backgroundColor: 'transparent',
                borderColor: '#f9a31b',
                pointHoverBackgroundColor: '#fff',
                borderWidth: 1,
                borderDash: [8, 5],
                data: minScoreFemale
              }
            ]
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
                    beginAtZero: true,
                    stepSize: 20,
                    max: 140
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
        },
      }
    }
</script>
