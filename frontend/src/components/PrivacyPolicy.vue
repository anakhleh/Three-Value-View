<template lang="html">

  <section class="privacy-policy">
    <h2>Privacy Policy</h2>
    <p>
      We do not use cookies, log any data about you, and do not log or store any of the images
      which are processed using this website.
    </p>
    <p>
      The code of this website is open source, licensed under the GPLv3.
    </p>
    <p>
      
    </p>
    <p>
      If you have any questions about this website's privacy policy or other website, please contact us at 
      <a :href="contactEmailHref">{{contactEmail}}</a> or contact Alex through
      <a :href="contactWebsite">{{contactWebsite}}</a>
    </p>
  </section>

</template>

<script lang="js">
import { AppConfiguration } from '../../app.config.js'

  export default  {
    name: 'PrivacyPolicy',
    props: [],
    mounted() {
    },
    data() {
      return {
        contactEmail: AppConfiguration.contactEmail,
        contactEmailHref: 'mailto:' + AppConfiguration.contactEmail,
        contactWebsite: AppConfiguration.contactWebsite,
      }
    },
    methods: {
    },
    computed: {
    }
}
</script>

<style scoped lang="scss">
  .privacy-policy {

  }
</style>
