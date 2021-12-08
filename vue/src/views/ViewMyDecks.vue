<template>
  <div>
    <h2>These are all of your decks</h2>
    <div id="list">
      <!-- <p>This would be the front of the card</p>
    <p>This would be the back of the card</p> -->
      <!-- Call the study card component with specific information -->

      <deck
        v-for="deck of $store.state.userDecks"
        v-bind:key="deck.id"
        v-bind:deck="deck"
      />
      <create-deck />
    </div>
  </div>
</template>

<script>
import CreateDeck from '../components/CreateDeck.vue';
import Deck from "../components/Deck.vue";
import FlashCardService from "../services/FlashCardService.js";

export default {
  components: {
    Deck,
    CreateDeck,
  },
  
  created() {
    FlashCardService.fetchMyDecks()
      .then((response) => {
        this.$store.commit("SET_USER_DECKS", response.data)
        console.log(response);
      })
      .catch((error) => {
        console.error(error);
      });
  },
};
</script>

<style>
#list {
  display: flex;
  justify-content: space-between;
}
</style>