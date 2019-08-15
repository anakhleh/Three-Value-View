<template>
  <div id="app">
    <h1>Three Value View</h1>
    <br>
    <ThreeValueViewCore id="ThreeValueViewCore" />
    <br>
    <hr>
    <PrivacyPolicy id="PrivacyPolicy"/>
  </div>
</template>

<script>
import ThreeValueViewCore from './components/ThreeValueViewCore.vue'
import PrivacyPolicy from './components/PrivacyPolicy.vue'

export default {
  name: 'app',
  components: {
    ThreeValueViewCore,
    PrivacyPolicy
  }
}
</script>

<style>
* {
  background: #eeeeee;
}
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
#ThreeValueViewCore{
  /* margin-top: 50px; */
  margin-bottom: 50px;
}
#PrivacyPolicy {
  margin-top: 50px;
  margin-bottom: 20px;
}
</style>
