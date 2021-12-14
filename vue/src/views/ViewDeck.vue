<template>
  <div id="cards">
    <div id="card-list">
      <study-card
        v-for="card of $store.state.activeDeck"
        v-bind:key="card.id"
        v-bind:card="card"
      />
    </div>
    <div id="side-bar-nav">
      <side-bar-view id="side-bar-options"/>
    </div>
  </div>
</template>

<script>
import StudyCard from "../components/StudyCard.vue";
import FlashCardService from "../services/FlashCardService.js";
import SideBarView from './SideBarView.vue';
// import CreateCardView from '../views/CreateCardView.vue'
export default {
  components: {
    StudyCard,
    SideBarView,
  },

  created() {
    FlashCardService.fetchDeck(this.$route.params.deckId)
      .then((response) => {
        this.$store.commit("SET_ACTIVE_DECK", response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  },
};
</script>

<style>
#cards {
  display: grid;
  grid-template-columns: 1.5fr 4fr;
  grid-template-areas:
    "sideBar allCards";
    height: 100%;
}

#card-list {
  grid-area: allCards;
  display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
  margin: 1rem;
}

#side-bar-nav {
  display: flex;
  height: 100%;
  background-color: #023047;
  justify-content: center;
  height: 100%;
}

#side-bar-options {
  position: fixed;
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 100px;
}


</style>