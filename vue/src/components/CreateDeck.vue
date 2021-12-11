<template>
  <div>
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
#new-deck {
  padding-top: 30px;
  resize: none;
  text-align: center;
  align-items: center;
  font-size: 20px;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(32, 28, 27);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 180px;
  height: 100px;
  margin: 0px;
}

#addDeckBtn {
  margin-top: 10px;
  width: 80px;
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