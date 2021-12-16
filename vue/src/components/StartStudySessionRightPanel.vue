<template>
  <div id="checkBox">
    <button id="start" v-on:click.prevent="startSession()">Study Deck</button>
    <div id="something-something">
      <label id="randomizeLabel" for="checkbox">Randomize Cards?</label>
      <input type="checkbox" id="randomize" v-on:change="random($event)" />
    </div>
  </div>
</template>

<script>
import FlashCardService from "../services/FlashCardService.js";

export default {
  methods: {
    random() {
      if (event.target.checked) {
        let maxIndex = this.$store.state.activeDeck.length;
        for (let a = 0; a < maxIndex; a++) {
          let randomIndex = Math.floor(Math.random() * maxIndex);
          let randomIndexSwap = Math.floor(Math.random() * maxIndex);
          let substitute = this.$store.state.activeDeck[randomIndex];
          this.$store.state.activeDeck[
            randomIndex
          ] = this.$store.state.activeDeck[randomIndexSwap];
          this.$store.state.activeDeck[randomIndexSwap] = substitute;
        }
        // FlashCardService.fetchDeck(this.$route.params.deckId)
        //   .then((response) => {
        //     this.$store.commit("SET_ACTIVE_DECK", );
        //   })
        //   .catch((error) => {
        //     console.error(error);
        //   });
      }

      if (!event.target.checked) {
        FlashCardService.fetchDeck(this.$route.params.deckId)
          .then((response) => {
            this.$store.commit("SET_ACTIVE_DECK", response.data);
          })
          .catch((error) => {
            console.error(error);
          });
      }
    },

    startSession() {
      this.$router.push({ name: "StudySession" });
    },
  },
};
</script>

<style lang="scss">
@import "../styles/colors.scss";

#start {
  color: white;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  border: solid 1px #c44e00;
  box-shadow: 0 2px 5px 0 #af4600;
  border-radius: 7px;
  width: 200px;
  height: 100px;
  font-size: 28px;
}

#checkBox {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

#something-something {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 10px;
}

#randomizeLabel {
  color: black;
  margin: 0px;
  font-size: 18px;
}
</style>