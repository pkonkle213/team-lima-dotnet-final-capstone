<template>
<div>
      <textarea
        class="cardOne"
        v-bind:class="{'cardTwo': clickCouner===1}"
        ref="newcard"
        type="text"
        name="cardName"
        v-model="text"
        
      />
      <div>
          <button type="submit" v-on:click.prevent="saveCard()">{{ buttonText }}</button>
      </div>
</div>
</template>

<script>
import FlashCardService from '../services/FlashCardService.js'

export default {
    
    data() {
        return {
            card: {
                //We need to add the card id? $store.deck.length?
                frontText: "",
                backText: "",
                deckId: +this.$route.params.deckId,
            },
            clickCouner: 0,
            text: ""
        }
    },
    computed: {
        buttonText() {
            if (this.clickCouner === 0) {
                return "Submit Front Text";
            }
            else if (this.clickCouner === 1) {
                return "Submit card";
            }
            return "";
        }
    },
    methods: {
        saveCard() {
            if (this.clickCouner === 0) {
                this.card.frontText = this.text;
                this.text = "";
                this.clickCouner++;
            }
            else if (this.clickCouner === 1)
            {
                this.card.backText = this.text;
            FlashCardService
            .addNewCard(this.card.deckId, this.card)
            .then(response => {
                console.log(response)
                this.$store.commit("ADD_CARD", response.data)
            })
            .catch(error => {
                console.error(error)
            })
            this.text = "";
            this.clickCouner = 0;
            this.card= {
                frontText: "",
                backText: ""
            }
            }
        }
    },
    
}
</script>

<style>
.cardOne {
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(32, 28, 27);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 380px;
  height: 300px;
  margin: 10px 10px 10px 10px;
  resize: none;
}

.cardTwo {
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(194, 49, 13);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 380px;
  height: 300px;
  margin: 10px 10px 10px 10px;
  resize: none;
}
</style>