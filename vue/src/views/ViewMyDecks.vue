<template>
  <section>
    <h2>This is a card</h2>
    <!-- <p>This would be the front of the card</p>
    <p>This would be the back of the card</p> -->
    <!-- Call the study card component with specific information -->

    <deck v-for="deck of cardDecks" v-bind:key="deck.id" v-bind:deck="deck"/>

  </section>
</template>

<script>
import Deck from '../components/Deck.vue'
import FlashCardService from '../services/FlashCardService.js'

export default {
    components: {
        Deck,
    },
    data() {
        return {
            cardDecks: [],
        }
    },
    created() {
      FlashCardService
        .fetchMyDecks()
        .then(response => {
          this.cardDecks = response.data
          console.log(response)
        })
        .catch(error => {
          console.error(error);
        })
    }
}
</script>

<style>

</style>