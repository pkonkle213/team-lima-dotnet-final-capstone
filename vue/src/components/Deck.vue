<template>
  <div class="deck-and-btn">
    <div class="deck">
      <span
        ref="deckName"
        id="deck-name"
        contenteditable="true"
        v-on:blur.prevent="changeDeckName()"
        >{{ deck.name }}</span
      >
    </div>
    <div class="btns">
      <button id="go-btn" v-on:click.prevent="goToDeck()">Open</button>
      <button id="delete-btn" v-on:click.prevent="deleteDeck()">Delete</button>
    </div>
  </div>
</template>

<script>
import FlashCardService from "../services/FlashCardService.js";

export default {
  props: {
    deck: Object,
  },
  methods: {
    goToDeck() {
      this.$router.push({ name: "ViewDeck", params: { deckId: this.deck.id } });
    },
    changeDeckName() {
      this.deck.name = this.$refs.deckName.innerText;
      FlashCardService.modifyDeck(this.deck)
        .then((response) => {
          {
            console.log(response);
            this.$store.commit("MODIFY_DECK", this.deck);
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
    deleteDeck() {
      FlashCardService.deleteDeck(this.deck.id)
      .then((response) => {
        console.log(response);
        this.$store.commit("DELETE_DECK", this.deck.id)
      })
      .catch(error => {
        console.log(error)
      })
    }
  },
};
</script>

<style>
.deck {
  display: flex;
  flex-wrap: wrap;
  text-align: center;
  flex-flow: row wrap;
  justify-content: center;
  align-items: center;
  border: 1px solid rgb(85, 82, 81);
  border-radius: 7px;
  width: 350px;
  min-width: 180px;
  max-width: 180px;
  height: 100px;
  margin: 10px;
  margin-top: 30px;

  background: rgb(255, 253, 253);
  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15), 0 10px 0 -5px #eee,
    0 10px 1px -4px rgba(0, 0, 0, 0.15), 0 20px 0 -10px #eee,
    0 20px 1px -9px rgba(0, 0, 0, 0.15);
}

.deck-and-btn {
  display: flex;
  flex-direction: column;
  align-items: center;
  color: black;
  font-size: 18px;
}

.btns {
  display: flex;
  width: 80%;
  justify-content: space-between;
}

#deck-name {
  border: none;
  outline: none;
}

#go-btn {
    width: 70px;
    height: 30px;
    background: linear-gradient(#eb5e00 10%, #ff9011 50%);
    color: white;
    border: solid 1px #c44e00;
    border-radius: 5px;
    box-shadow: 0 2px 5px 0 #af4600;
    text-align: center;
    margin: 10px 0 0 10px;
}

#delete-btn {
    width: 70ox;
    height: 30px;
    background: linear-gradient(#eb5e00 10%, #ff9011 50%);
    color: white;
    border: solid 1px #c44e00;
    border-radius: 5px;
    box-shadow: 0 2px 5px 0 #af4600;
    text-align: center;
    margin: 10px 0 0 10px;
}

</style>