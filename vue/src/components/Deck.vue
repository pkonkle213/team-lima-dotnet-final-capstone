<template>
  <div>
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
</style>