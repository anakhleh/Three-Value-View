<template lang="html">

  <section class="privacy-policy">
    <h2>Privacy Policy</h2>
    <p>
      We do not use cookies, log any data about you, and do not log or store any of the images
      which are processed using this website.
    </p>
    <h2>License</h2>
    <p>
      The code of this website is open source, licensed under the GPLv3.
      <br>
      <br>
      <a href="https://github.com/anakhleh/Three-Value-View" >
        <button type="button" class="viewOnGithubBtn">
          View the project on Github <img src='../assets/githubWhite.svg' class="githubIcon"></img>
        </button>
      </a>
    </p>
    <br>
    <h2>Contact</h2>
    <p>
      If you have any questions about this website's privacy policy or other website, please contact us at 
      <a :href="contactEmailHref">{{contactEmail}}</a> or contact us through
      <a :href="contactWebsiteHref" target="noopener noreferrer">{{contactWebsite}}</a>
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
        contactWebsiteHref: 'https://' + AppConfiguration.contactWebsite
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
  .viewOnGithubBtn{
    padding-top: 3px;
    padding-bottom: 3px;
    border: none;
    border-radius: 99999999px;
    background: #3399FF;
    color: #ffffff;
    box-shadow: 0px 10px 20px #727272;

  }
  .githubIcon{
    background: none;
    width: 35px;
    height: 35px;
    fill: #ffffff;
    display: inline;
  }
</style>
