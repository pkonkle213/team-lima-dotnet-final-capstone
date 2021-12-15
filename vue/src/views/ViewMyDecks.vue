<template>
  <div id="main-decks">
    <div class="list">
      <deck
        id="decks"
        v-for="deck of $store.state.userDecks"
        v-bind:key="deck.id"
        v-bind:deck="deck"
      />
    </div>
      <create-deck class="add-deck"/>
    <div class="empty-side-right"></div>
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

<style lang="scss">
@import '../styles/colors.scss';

#main-decks {
  display: grid;
  grid-template-columns: 1fr 2fr 1fr;
  grid-template-rows: 0.2fr 1fr;
  grid-template-areas: 
    "emptySidebarLeft cards emptySidebarRight"
    "emptySidebarLeft cards emptySidebarRight";
}
.list {
  height: 100%;
  grid-area: cards;
  align-self: start;
  display: flex;
  flex-wrap: wrap;
  margin-left: 6.5%;
  overflow-y: auto;
}

.add-deck {
  grid-area: emptySidebarLeft;
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: flex-end;
  justify-self: start;
  margin-left: 6.5%;
  margin-top: 3%;
  gap: 6%;
  background: linear-gradient(#f1eeee 10%, #ffffff 50%);
}



.empty-side-right {
  grid-area: emptySidebarRight;
  min-height: 100%;
  background: linear-gradient(#f1eeee 10%, #ffffff 50%);
}


</style>