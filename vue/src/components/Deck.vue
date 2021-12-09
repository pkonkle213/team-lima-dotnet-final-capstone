<template>
  <div class="deck">
    <router-link v-bind:to="{ name: 'ViewDeck', params: { deckId: deck.id } }"
      >{{ deck.name }}</router-link
    >
  </div>
</template>

<script>
export default {
  props: {
    deck: Object,
  },
};
</script>

<style>

.deck {
  display: flex;
  flex-wrap: wrap;
  flex-flow: row wrap;
  justify-content: center;
  align-items: center;
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(32, 28, 27);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 350px;
  min-width: 180px;
  max-width: 180px;
  height: 100px;
  margin: 10px;
  }

</style>