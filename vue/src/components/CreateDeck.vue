<template>
  <form v-on:submit.prevent>
      <div>
          <label for="deckName">The name of the deck:</label>
          <input type="text" name="deckName" v-model="newDeck.name" />
      </div>
      <div>
          <button type="submit" v-on:click.prevent="addNewDeck()">Add Deck</button>
      </div>
  </form>
</template>

<script>
import FlashCardService from "../services/FlashCardService.js"

export default {
    data() {
        return {
            newDeck: {
                name: ""
            }
        }
    },
    methods: {
        addNewDeck() {
            FlashCardService
            .addNewDeck(this.newDeck)
            .then(response => {
                this.$store.commit("ADD_DECK", response.data)
            })
            .catch(error => {
                console.error(error)
            })
        }
    }
}
</script>

<style>

</style>