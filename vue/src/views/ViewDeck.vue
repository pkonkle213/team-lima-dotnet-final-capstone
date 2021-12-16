<template>
  <div id="cards">
    <div v-show="!$store.state.activeDeck.length" id="loading">
    </div>

    <div id="card-list" v-show="$store.state.activeDeck">
    <div v-show="!$store.state.activeDeck.length" class="lds-grid"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>

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

  mounted() {
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

::-webkit-scrollbar {
  width: 20px;
}

::-webkit-scrollbar-track {
  box-shadow: inset 0 0 5px grey;
  border-radius: 10px;
}

::-webkit-scrollbar-thumb {
  background: radial-gradient(#ffffff 10%, #e4e4e4 50%);
  box-shadow: inset 0 0 5px grey;
  border-radius: 10px;
}

#startStudying {
  display: flex;
  flex-direction: column;
  justify-self: center;
  justify-content: center;
  gap: 10px;
}

#rightPanel {
  height: 100%;
  width: 100%;
  background-color: #023047;
  background: linear-gradient(#e6e6e6 10%, #ffffff 50%);
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
  align-content: flex-start;
}

#side-bar-nav {
  display: flex;
  height: 100%;
  background-color: #023047;
  background: linear-gradient(#e6e6e6 10%, #ffffff 50%);
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

.lds-grid {
  margin-top: 25%;
  display: inline-block;
  position: relative;
  width: 80px;
  height: 80px;
}

.lds-grid div {
  position: absolute;
  width: 16px;
  height: 16px;
  border-radius: 50%;
  background: #eb5e00;
  animation: lds-grid 1.2s linear infinite;
}
.lds-grid div:nth-child(1) {
  top: 8px;
  left: 8px;
  animation-delay: 0s;
}
.lds-grid div:nth-child(2) {
  top: 8px;
  left: 32px;
  animation-delay: -0.4s;
}
.lds-grid div:nth-child(3) {
  top: 8px;
  left: 56px;
  animation-delay: -0.8s;
}
.lds-grid div:nth-child(4) {
  top: 32px;
  left: 8px;
  animation-delay: -0.4s;
}
.lds-grid div:nth-child(5) {
  top: 32px;
  left: 32px;
  animation-delay: -0.8s;
}
.lds-grid div:nth-child(6) {
  top: 32px;
  left: 56px;
  animation-delay: -1.2s;
}
.lds-grid div:nth-child(7) {
  top: 56px;
  left: 8px;
  animation-delay: -0.8s;
}
.lds-grid div:nth-child(8) {
  top: 56px;
  left: 32px;
  animation-delay: -1.2s;
}
.lds-grid div:nth-child(9) {
  top: 56px;
  left: 56px;
  animation-delay: -1.6s;
}
@keyframes lds-grid {
  0%, 100% {
    opacity: 1;
  }
  50% {
    opacity: 0.5;
  }
}

</style>