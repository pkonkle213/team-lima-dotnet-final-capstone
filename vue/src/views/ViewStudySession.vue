<template>
  <section>
    <study-session-card />
    <timer v-show="this.$store.state.lightningSession"/>
  </section>
  <img src="..\img\cropped_brain.jpg" id="dab">
</template>

<script>
import StudySessionCard from '../components/StudySessionCard.vue';
import Timer from '../components/Timer.vue'

export default {
  components: {
    StudySessionCard,
    Timer
  }
}
</script>

<style>

</style>