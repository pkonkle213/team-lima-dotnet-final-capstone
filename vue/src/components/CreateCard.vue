<template>
  <form v-on:submit.prevent>
      <div>
          <label for="frontText">Text on the front of the card:</label>
          <input type="text" name="frontText" v-model="card.frontText" />
      </div>
      <div>
          <label for="backText">Text on the back of the card:</label>
          <input type="text" name="backText" v-model="card.backText" />
      </div>
      <div>
          <button type="submit" v-on:click.prevent="saveCard()">Submit new card</button>
      </div>
  </form>
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
            }
        }
    },
    methods: {
        saveCard() {
            FlashCardService
            .addNewCard(this.card.deckId, this.card)
            .then(response => {
                console.log(response)
                this.$store.commit("ADD_CARD", response.data)
            })
            .catch(error => {
                console.error(error)
            })

            this.card= {
                frontText: "",
                backText: ""
            }
        }
    },
    
}
</script>

<style>

</style>