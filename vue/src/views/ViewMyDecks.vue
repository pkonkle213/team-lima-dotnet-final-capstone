<template>
  <div id="main">
    <create-deck id="add-deck"/>
    <div id="list">
      <!-- <p>This would be the front of the card</p>
    <p>This would be the back of the card</p> -->
      <!-- Call the study card component with specific information -->

      <deck
        id="decks"
        v-for="deck of $store.state.userDecks"
        v-bind:key="deck.id"
        v-bind:deck="deck"
      />
    </div>
  </div>
</template>

<script>
import CreateDeck from "../components/CreateDeck.vue";
import Deck from "../components/Deck.vue";
import FlashCardService from "../services/FlashCardService.js";

export default {
  name: "ViewMyDecks",
  components: {
    Deck,
    CreateDeck,
  },

  created() {
    FlashCardService.fetchMyDecks()
      .then((response) => {
        this.$store.commit("SET_USER_DECKS", response.data);
        console.log(response);
      })
      .catch((error) => {
        console.error(error);
      });
  },
};
</script>

<style>
#main {
  display: grid;
  grid-template-columns: 1fr 2fr 1fr;
  grid-template-rows: .1fr 1fr 1fr;
  grid-template-areas: 
    "... add ..."
    "... cards ..."
    ". . .";
}
#list {
  grid-area: cards;
  align-self: start;
  display: flex;
  flex-wrap: wrap;
  margin-left: 6.5%;
}

#add-deck {
  grid-area: add;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-self: center;
  align-self: center;
}
</style>