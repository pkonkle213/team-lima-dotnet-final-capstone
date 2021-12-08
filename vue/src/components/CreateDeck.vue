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
export default {
    data() {
        return {
            newDeck: {},
        }
    },
    methods: {
        addNewDeck() {
            
        }
    }
}
</script>

<style>

</style>