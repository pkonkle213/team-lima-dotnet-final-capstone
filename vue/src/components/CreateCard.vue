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
          <button type="submit" v-on:click="saveCard()">Submit new card</button>
      </div>
  </form>
</template>

<script>
// Need to import the service to save the new card

export default {
    props: ["deckId"],
    data() {
        return {
            card: {
                //We need to add the card id? $store.deck.length?
                frontText: "",
                backText: "",
                deckId: this.deckId,
            }
        }
    },
    methods: {
        saveCard() {
            console.log("This will eventually submit and save a card to a deck")
        }
    }
}
</script>

<style>

</style>