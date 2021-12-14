<template> 
<div id="deck-and-btn">
  <div class="deck">
    <router-link v-bind:to="{ name: 'ViewDeck', params: { deckId: deck.id } }"
      >{{ deck.name }}</router-link
    >
  </div>
    <button v-on:click.prevent="goToDeck()">Go to deck</button>
</div>
</template>

<script>
export default {
  props: {
    deck: Object,
  },

  methods: {
    goToDeck() {
      this.$router.push({name: 'ViewDeck', params: { deckId: this.deck.id } })
    }
  }
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

  background: rgb(255, 253, 253);
  box-shadow:
    0 1px 1px rgba(0,0,0,0.15),
    0 10px 0 -5px #eee,
    0 10px 1px -4px rgba(0,0,0,0.15),
    0 20px 0 -10px #eee,
    0 20px 1px -9px rgba(0,0,0,0.15);
}

#deck-and-btn {
  display: flex;
  flex-direction: column;
  justify-items: center;
}

</style>