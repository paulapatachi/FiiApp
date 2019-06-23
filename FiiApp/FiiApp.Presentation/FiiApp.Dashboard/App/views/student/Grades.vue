<template>
  <div class="animated fadeIn">
    <b-card class="boxModel-zero sortable" header-bg-variant="primary" header="The trajectory of the student">
      <b-table class="table table-borderless table-primary" hover striped outlined small responsive="sm" :items="trajectoryData" :fields="trajectoryFields" @row-clicked="semesterClicked" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
    <b-card class="boxModel-zero sortable" header-bg-variant="primary" header="Student grades">
      <b-table class="table table-borderless table-primary" hover striped outlined small responsive="sm" :items="finalGradesData" :fields="finalGradesFields" @row-clicked="courseClicked" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
    <b-card class="boxModel-zero" header-bg-variant="primary" :header="currentCourseClicked">
      <b-table class="table table-borderless table-primary" striped outlined small responsive="sm" :items="gradesData" :fields="gradesFields" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
    <b-card class="boxModel-zero" header-bg-variant="primary" header="Student averages">
      <b-table class="table table-borderless table-primary" striped outlined small responsive="sm" :items="meansData" :fields="meansFields" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
  name: 'c-table',
  inheritAttrs: false,
  props: {
  },
  data: () => {
    return {
      trajectoryFields: [
        { key: 'academicYear', label: 'Academic Year', class: 'text-center' },
        { key: 'studyYear', label: 'Study Year', class: 'text-center' },
        { key: 'semester', label: 'Semester', class: 'text-center' },
        { key: 'class', label: 'Class', class: 'text-center' },
        { key: 'specialization', label: 'Specialization', class: 'text-center' },
      ],

      gradesFields: [
        { key: 'evaluationName', label: 'Name', class: 'text-center', sortable: true },
        { key: 'evaluationType', label: 'Type', class: 'text-center', sortable: true },
        { key: 'teacherName', label: 'Teacher Name', class: 'text-center', sortable: true },
        { key: 'maxScore', label: 'Max Score', class: 'text-center', sortable: true },
        { key: 'yourScore', label: 'Your Score', class: 'text-center', sortable: true },
        { key: 'grade', label: 'Your Grade', class: 'text-center', sortable: true },
        { key: 'evalDate', label: 'Date', class: 'text-center', sortable: true },
      ],

      meansFields: [
        { key: 'semester', label: 'Semester', class: 'text-center' },
        { key: 'average', label: 'Average', class: 'text-center' },
        { key: 'ectsMean', label: 'ECTS Mean', class: 'text-center' },
        { key: 'points', label: 'Points', class: 'text-center' },
        { key: 'credits', label: 'Credits', class: 'text-center' },
        { key: 'averageYear', label: 'Average Per Year', class: 'text-center' },
        { key: 'ectsMeanYear', label: 'ECTS Mean Per Year', class: 'text-center' },
        { key: 'pointsYear', label: 'Points Per Year', class: 'text-center' },
        { key: 'creditsYear', label: 'Credits Per Year', class: 'text-center' },
      ],

      finalGradesFields: [
        { key: 'academicYear', label: 'Academic Year', class: 'text-center' },
        { key: 'semester', label: 'Semester', class: 'text-center' },
        { key: 'courseName', label: 'Course Name', class: 'text-center', sortable: true },
        { key: 'grade', label: 'Final Grade', class: 'text-center', sortable: true },
        { key: 'credits', label: 'Credits', class: 'text-center', sortable: true },
        { key: 'date', label: 'Date', class: 'text-center', sortable: true },
      ],

      finalGradesData: [],
      gradesData: [],
      trajectoryData: [],
      meansData: [],
      studentInfo: {},
      currentCourseClicked: 'Course'
    }
  },
  computed: {
    items: function() {
      const items =  trajectoryData
      return Array.isArray(items) ? items : items()
    }
  },
    methods: {
      semesterClicked(item) {
        this.getStudentFinalGrades(item.semester)
      },

      courseClicked(item) {
        this.currentCourseClicked = item.courseName
        this.getStudentGrades(item.courseId)
      },
      
      getStudentClassAndEnrollmentYear() {
        let url = document.getElementById('axiosUrls').getAttribute('data-studentClassANdEnrollmentYearUrl')
        axios.get(url)
          .then(response => {
            this.studentInfo = response.data
            this.getStudentTrajectory()
          })
      },

      getStudentTrajectory() {
        let year = this.studentInfo.academicYear
        let stdclass = this.studentInfo.studentClass
        this.trajectoryData = [
          { academicYear: year, studyYear: 1, semester: 1, class: stdclass, specialization: 'Computer science' },
          { academicYear: year, studyYear: 1, semester: 2, class: stdclass, specialization: 'Computer science' },
          { academicYear: year + 1, studyYear: 2, semester: 3, class: stdclass, specialization: 'Computer science' },
          { academicYear: year + 1, studyYear: 2, semester: 4, class: stdclass, specialization: 'Computer science' },
          { academicYear: year + 2, studyYear: 3, semester: 5, class: stdclass, specialization: 'Computer science' },
          { academicYear: year + 2, studyYear: 3, semester: 6, class: stdclass, specialization: 'Computer science' },
        ]
      },

      getStudentFinalGrades(semester) {
        let url = document.getElementById('axiosUrls').getAttribute('data-studentFinalGradesUrl')
        axios.get(url, { params: { semester: semester } })
          .then(response => {
            this.finalGradesData = response.data
          })
      },

      getStudentGrades(course) {
        let url = document.getElementById('axiosUrls').getAttribute('data-studentGradesUrl')
        axios.get(url, { params: { courseId: course } })
          .then(response => {
            this.gradesData = response.data
          })
      },

      getStudentGradesMeans() {
        let url = document.getElementById('axiosUrls').getAttribute('data-studentGradesMeansUrl')
        axios.get(url)
          .then(response => {
            this.meansData = response.data
          })
      }
    },

    beforeMount() {
      this.getStudentFinalGrades(1)
      this.getStudentClassAndEnrollmentYear()
      this.getStudentGradesMeans()
    }
}
</script>

<style>
  .boxModel-zero .card-body {
    padding: 0;
  }

  .boxModel-zero .card-header {
    border: 0;
  }

  .boxModel-zero .card-body .table{
    margin: 0;
  }

  .table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
    background-color: skyblue;
  }

  .sortable tr {
    cursor: pointer;
  }

</style>
