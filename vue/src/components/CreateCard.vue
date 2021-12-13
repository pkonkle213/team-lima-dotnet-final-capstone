<template>
    <div>
        <textarea
         id="frontCard"
         class="frontCard"
         v-bind:class="{'backCard': clickCounter===1}"
         ref="newcard"
         type="text"
         name="cardName"
         v-model="text">
        </textarea>
        <div>
            <button type="submit" v-on:click.prevent="saveCard()"> {{ buttonText }} </button>
        </div>
    </div>
</template>

<script>
import FlashCardService from '../services/FlashCardService.js';
export default {
    data() {
        return {
            card: {
                //We need to add the card id? $store.deck.length?
                frontText: "",
                backText: "",
                deckId: +this.$route.params.deckId,
            },
            clickCounter: 0,
            text: "",
        }
    },
    computed: {
        buttonText() {
            if (this.clickCounter === 0) {
                return "Submit Front Text";
            } else if (this.clickCounter === 1) {
                return "Submit card";
            }
            return "test";
        },
        placeHolderText() {
            if (this.clickCounter === 0) {
                return "Enter front text!";
            } else if (this.clickCounter === 1) {
                return "Enter back text!";
            } 
            return "test";
        },
    },
    methods: {
        saveCard() {
            if (this.clickCounter === 0) {
                this.card.frontText = this.text;
                this.text = "";
                this.clickCounter++;
            } else if (this.clickCounter === 1) {
                this.card.backText = this.text;

                FlashCardService.addNewCard(this.card.deckId, this.card).then(response => {
                    console.log(response)
                    this.$store.commit("ADD_CARD", response.data)
                })

                .catch(error => {
                    console.error(error.data);
                })

                this.text = "";
                this.clickCounter = 0;
                this.card.frontText = "";
                this.card.backText = "";
            }
        }
    },
}
</script>

<style lang="scss">
@import '../styles/colors.scss';


//are we using # or . frontCard?
#frontCard {
  padding-top: 70px;
  resize: none;
  text-align: center;
  align-items: center;
  font-size: 30px;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(73, 39, 31);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 380px;
  height: 200px;
  margin: 10px 10px 10px 10px;
}

.frontCard {
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(73, 39, 31);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 380px;
  height: 200px;
  margin: 10px 10px 10px 10px;
  resize: none;
}

.backCard {
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(194, 49, 13);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 380px;
  height: 200px;
  margin: 10px 10px 10px 10px;
  resize: none;
}

</style>