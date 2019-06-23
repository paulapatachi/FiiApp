<template>
  <div class="animated fadeIn">
    <b-list-group>
      <template v-for="(item, index) in teachers">
        <teacher :teacherInfo="item"></teacher>
      </template>
     </b-list-group>
</div>
</template>

<script>
  import axios from 'axios'
  import Teacher from "./Teacher"

  export default {
    name: 'TeachersList',
    components: {
      Teacher
    },
    props: {
    },
    data: () => {
      return {
        teachers: [],
        items: ["Paula", "Alexandra", "Oana"],
        teacher: {
          firstName: "Paula",
          lastName: "Patachi",
          rank: "Student",
          office: "here",
          webAddress: "here",
          email: "paula.patachi@info.uaic.ro",
          areasOfInterest: "Professor"
        }
      }
    },
    methods: {
      getTeachers() {
      let url = document.getElementById('axiosUrls').getAttribute('data-teachersUrl')
      axios.get(url)
        .then(response => {
          this.$data.teachers = response.data
        })
      }
    },

    mounted() {
      this.getTeachers()
    }
  }
</script>


