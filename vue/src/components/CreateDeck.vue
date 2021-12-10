<template>
  <div id="card">
    <button v-if="!showForm" id="card" v-on:click.prevent="toggleForm()">
      +
    </button>
    <form v-on:submit.prevent>
      <div v-if="showForm">
        <label for="deckName">The name of the deck: </label>
        <input type="text" name="deckName" v-model="newDeck.name" />
      </div>
      <div>
        <button v-if="showForm" type="submit" v-on:click.prevent="addNewDeck()">
          Add Deck
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import FlashCardService from "../services/FlashCardService.js";

export default {
  data() {
    return {
      showForm: false,
      newDeck: {
        name: "",
      },
    };
  },
  methods: {
    toggleForm() {
      if (!this.showForm) {
        this.showForm = true;
      } else if (this.showForm) {
        this.showForm = false;
      }
    },
    addNewDeck() {
      FlashCardService.addNewDeck(this.newDeck)
        .then((response) => {
          this.$store.commit("ADD_DECK", response.data);
        })
        .catch((error) => {
          console.error(error);
        });
    },
  },
};
</script>

<style>
#card {
  display: flex;
  justify-self: center;
  justify-content: center;
  align-items: center;
  font-size: 300%;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(32, 28, 27);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 180px;
  height: 100px;
  margin: 0;
}
</style>