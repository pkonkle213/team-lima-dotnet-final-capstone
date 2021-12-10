<template>
  <div>
    <form id="card">
      <textarea
        id="new-card"
        ref="newcard"
        type="text"
        name="deckName"
        v-model="newDeck.name"
      />
    </form>
    <div>
      <button type="submit" v-on:click.prevent="addNewDeck()">+</button>
    </div>
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
    // scaleInputText() {
    //   let text = this.$refs.newcard;
    //   var initialSize = 25 - text.value.length;
    //   initialSize = initialSize <= 10 ? 10 : initialSize;
    //   text.style.fontSize = initialSize + "px";
    // },
  },
};
</script>

<style>
#new-card {
  resize: none;
  text-align: center;
  font-size: 20px;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(32, 28, 27);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 180px;
  height: 100px;
  margin: 0;
}
</style>