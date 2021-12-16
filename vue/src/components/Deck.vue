<template>
  <div class="deck-and-btn" v-on:mouseover="showButtons()" v-on:mouseleave="hideButtons()">
    <div class="deck">
      <span ref="deckName" id="deck-name" contenteditable="true" v-on:blur.prevent="changeDeckName()">{{ deck.name }}</span>
    </div>

    <div class="btns" v-show="displayButtons">
      <button id="go-btn" v-on:click.prevent="goToDeck()">View</button>
      <button id="delete-btn" v-on:click.prevent="deleteDeck()"></button>
    </div>
  </div>
</template>

<script>
import FlashCardService from "../services/FlashCardService.js";
export default {
  data() {
    return {
      displayButtons: false
    }
  },
  props: {
    deck: Object,
  },
  methods: {
    goToDeck() {
      this.$store.state.activeDeck = [];
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
    },
    showButtons(){
      this.displayButtons = true;
    },
    hideButtons() {
      this.displayButtons = false;
    }
  },
};
</script>

<style lang="scss">
@import '../styles/colors.scss';

.deck {
  display: flex;
  text-align: center;
  flex-flow: row wrap;
  justify-content: center;
  align-items: center;
  border: 1px solid rgb(85, 82, 81);
  border-radius: 7px;
  width: 270px;
  height: 140px;
  min-width: 270px;
  margin: 10px;
  background: linear-gradient(#f1eeee 10%, #ffffff 50%);

  box-shadow: 0 1px 1px rgba(0, 0, 0, 0.15), 0 10px 0 -5px #eee,
    0 10px 1px -4px rgba(46, 46, 46, 0.15), 0 20px 0 -10px #eee,
    0 20px 1px -9px rgba(0, 0, 0, 0.15);
}

.deck:hover {
  cursor: text;
}

#deck-name {
  width: 95%;
}

.deck-and-btn {
  display: flex;
  height: 230px;
  flex-direction: column;
  align-items: flex-end;
  color: black;
  font-size: 18px;
}

.btns {
  display: flex;
  width: 80%;
  align-self: center;
  justify-content: space-between;
}

.btns:hover {
  cursor: pointer;
}

#deck-name {
  border: none;
  outline: none;
}

#go-btn {
  width: 100px;
  height: 49px;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  color: white;
  border: solid 1px #c44e00;
  border-radius: 5px;
  box-shadow: 0 2px 5px 0 #af4600;
  text-align: center;
  margin-top: 10px;
}

#go-btn:hover {
  text-shadow:
  0 0 7px #fff,
  0 0 10px #fff,
  0 0 21px #fff,
  0 0 25px #fff, 
  0 0 30px #fff; 
}

#delete-btn {
  width: 45px;
  height: 49px;
  background:url(../img/RE4CA2I.jpeg) no-repeat;
  color: white;
  border: solid 1px #c44e00;
  border-radius: 5px;
  box-shadow: 0 2px 5px 0 #af4600;
  text-align: center;
  margin-top: 10px;
  background:url(../img/Webp.net-resizeimage.png)
}

</style>