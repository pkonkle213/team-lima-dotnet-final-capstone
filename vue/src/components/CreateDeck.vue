<template>
  <div id ="deck-view">
    <form id="deck">
      <textarea placeholder="Add a new deck" maxlength="40"
        id="new-deck"
        ref="newcard"
        type="text"
        name="deckName"
        v-model="newDeck.name"
      />
    </form>
    <div>
      <button id="addDeckBtn" type="submit" v-on:click.prevent="addNewDeck()">Add</button>
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
        userId: this.$store.state.user.userId,
        description: ""
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

        this.newDeck.name = "";
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

#deck-view {
  display: flex; 
  flex-direction: column;
}

#new-deck {
  padding-top: 30px;
  resize: none;
  text-align: center;
  align-items: center;
  font-size: 20px;
  background-color: rgb(255, 231, 215);
  border: 1px solid #c44e00;
  border-radius: 5px;
  width: 180px;
  height: 100px;
  margin-bottom: 2.77%;
  margin: 0px;
    box-shadow:
    0 1px 1px rgba(102, 67, 67, 0.3),
    0 10px 0 -5px rgb(235, 193, 170),
    0 10px 1px -4px rgba(0,0,0,0.15),
    0 20px 0 -10px rgb(235, 193, 170),
    0 20px 1px -9px rgba(0,0,0,0.15);
}

#addDeckBtn {
  margin-top: 10px;
  margin-bottom: 7%;
  width: 180px;
  height: 30px;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  color: white;
  border: solid 1px #c44e00;
  border-radius: 7%;
  box-shadow: 0 2px 5px 0 #af4600;
}

#addDeckBtn:hover {
    text-shadow:
      0 0 7px #fff,
      0 0 10px #fff,
      0 0 21px #fff,
      0 0 25px #fff, 
      0 0 30px #fff; 
}



</style>