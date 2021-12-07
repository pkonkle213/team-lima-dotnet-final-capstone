<template>
  <section>
    <h2>This is a card</h2>
    <!-- <p>This would be the front of the card</p>
    <p>This would be the back of the card</p> -->
    <!-- Call the study card component with specific information -->

    <study-session v-bind:cardDeck="cardDeck"/>

  </section>
</template>

<script>
import StudySession from '../components/StudySession.vue'
import FlashCardService from '../services/FlashCardService.js'

export default {
    components: {
        StudySession,
    },
    data() {
        return {
            cardDeck: []
        }
    },
    created() {
      FlashCardService
        .fetchDeck()
        .then(response => {
          this.cardDeck = response.data
        })
        .catch(response => {
          console.error("Could not fetch deck", response);
        })
    }
}
</script>

<style>

</style>