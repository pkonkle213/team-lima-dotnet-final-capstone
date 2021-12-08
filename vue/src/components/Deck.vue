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
  justify-content: center;
  align-items: center;
  border: 5px solid green;
  border-radius: 10px;
  width: 200px;
  height: 350px;
  margin: none;
}

</style>