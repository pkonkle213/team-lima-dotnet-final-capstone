<template>
  <div>
    <router-link v-bind:to="{ name: 'deck', params: { deckId: deck.id } }"
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