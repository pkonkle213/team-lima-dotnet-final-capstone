<template>
  <div id="cards">
    <div v-show="!$store.state.activeDeck.length" id="loading">
      <img src="../img/loading.svg">
    </div>
    <div id="card-list" v-show="$store.state.activeDeck">
      <study-card
        v-for="card of $store.state.activeDeck"
        v-bind:key="card.id"
        v-bind:card="card"
      />
    </div>
    <div id="side-bar-nav">
      <side-bar-view id="side-bar-options" />
    </div>
    <div id="rightPanel">
      <start-study-session-right-panel id="startStudying" />
      <img
        src="../img/d9006bced22dcde87db0dd29364b0c16-removebg-preview.png"
        alt="Brain"
        id="brainThink"
      />
    </div>
    <div id="image"></div>
  </div>
</template>

<script>
import StartStudySessionRightPanel from "../components/StartStudySessionRightPanel.vue";
import StudyCard from "../components/StudyCard.vue";
import FlashCardService from "../services/FlashCardService.js";
import SideBarView from "./SideBarView.vue";
// import CreateCardView from '../views/CreateCardView.vue'
export default {
  components: {
    StudyCard,
    SideBarView,
    StartStudySessionRightPanel,
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

<style lang="scss">
@import "../styles/colors.scss";

#startStudying {
  grid-template-areas: studySess;
}

#rightPanel {
  height: 100%;
  width: 100%;
  background-color: #023047;
  background: linear-gradient(#013047 30%, #6e8fa0 80%);
  border-left: solid 1px black;
  grid-area: studySess;

  display: grid;
  grid-template-columns: 2fr 1.4fr;
  grid-template-areas: "btn brain";
}

#startStudying {
  grid-area: btn;
  display: flex;
  align-self: flex-start;
  margin: 60px 0 0 60px;
}

#brainThink {
  grid-area: brain;
  display: flex;
  align-self: flex-start;
  justify-self: center;
  margin: 30px 0 0 0;
  height: 150px;
}

#cards {
  display: grid;
  grid-template-columns: 25vw 50vw 25vw;
  grid-template-rows: 1fr;
  grid-template-areas: "sideBar allCards studySess";
  height: 100%;
  overflow: hidden;
}

#loading {
  grid-area: allCards;
  height: 20%;
  display: flex;
  justify-content: center;
}

#card-list {
  grid-area: allCards;
  height: 100%;
  display: flex;
  flex-direction: row;
  justify-content: center;
  flex-wrap: wrap;
  margin: 1rem;
  overflow-y: auto;
}

#side-bar-nav {
  display: flex;
  height: 100%;
  background-color: #023047;
  background: linear-gradient(#013047 30%, #6e8fa0 80%);
  border-right: solid 1px black;
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