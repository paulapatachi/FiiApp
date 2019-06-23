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
        attendanceDataSet: null
      }
    },
    mounted() {
      this.getAttendanceStatistics()
    },
    watch: {
      attendanceDataSet() {
        // Overwriting base render method with actual data.
        
        var studyYears = this.attendanceDataSet.map(obj => obj.year)
        var seminarS1 = this.attendanceDataSet.map(obj => obj.seminarS1)
        var seminarS2 = this.attendanceDataSet.map(obj => obj.seminarS2)
        var consultationC1 = this.attendanceDataSet.map(obj => obj.consultationC1)
        var consultationC2 = this.attendanceDataSet.map(obj => obj.consultationC2)
        var totalResults = this.attendanceDataSet.map(obj => obj.totalNumber)

        this.renderChart(
          {
            labels: studyYears,
            datasets: [
              {
                label: 'Expected Attendance',
                backgroundColor: '#abc611',
                data: totalResults
              },
              {
                label: 'Seminar S1',
                backgroundColor: '#0f9e3c',
                data: seminarS1
              },
              {
                label: 'Seminar S2',
                backgroundColor: '#1edb9f',
                data: seminarS2
              },
              {
                label: 'Consultation C1',
                backgroundColor: '#6817b5',
                data: consultationC1
              },
              {
                label: 'Consultation C2',
                backgroundColor: '#daace5',
                data: consultationC2
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
      getAttendanceStatistics() {
        let url = document.getElementById('axiosUrls').getAttribute('data-attendanceStatisticsUrl')
        axios.get(url)
          .then(response => {
            this.attendanceDataSet = response.data
          })
      },
    }
}
</script>
