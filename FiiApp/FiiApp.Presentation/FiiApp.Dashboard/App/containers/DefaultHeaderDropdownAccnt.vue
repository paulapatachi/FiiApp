<template>
  <AppHeaderDropdown right no-caret>
    <template slot="header">
      <img
        src="img/profilePic.jpg"
        class="img-avatar"
        alt="admin@bootstrapmaster.com" />
    </template>\
    <template slot="dropdown">
      <b-dropdown-header
        tag="div"
        class="text-center">
        <strong>Settings</strong>
      </b-dropdown-header>
      <b-dropdown-item @click="userProfile"><i class="fa fa-user" /> Profile</b-dropdown-item>
      <b-dropdown-item><i class="fa fa-wrench" /> Settings</b-dropdown-item>

      <b-dropdown-item><i class="fa fa-shield" /> Lock Account</b-dropdown-item>
      <b-dropdown-item @click="logout()"><i class="fa fa-lock" /> Logout</b-dropdown-item>
    </template>
  </AppHeaderDropdown>
</template>

<script>
import { HeaderDropdown as AppHeaderDropdown } from '@coreui/vue'
export default {
  name: 'DefaultHeaderDropdownAccnt',
  components: {
    AppHeaderDropdown
  },
  data: () => {
    return { itemsCount: 42 }
    },

    computed: {
      isLoggedIn() {
        return this.$store.getters.isLoggedIn
      }
    },

    methods: {
      logout() {
        this.$store.dispatch('logout')
          .then(() => {
            this.$router.push('/login')
          })
      },

      userProfile() {
        this.$router.push('/profile')
      }
    },
}
</script>
