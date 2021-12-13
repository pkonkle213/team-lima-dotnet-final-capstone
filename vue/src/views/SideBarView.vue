<template>
  <div id="side-bar">
      <create-card-view />
      <router-link v-bind:to="{ name: 'StudySession' }">Start a study session with this deck</router-link>
  </div>
</template>

<script>
import CreateCardView from './CreateCardView.vue'
export default {
  components: { CreateCardView },

}
</script>

<style>
#side-bar {
  display: flex;
  flex-direction: column;
  gap: 100px;
}

</style>