<template>
  <button v-on:click.prevent="handleClick()">
    <!-- Display the front but on click it toggles to the back (and then front again) -->
    <study-card v-bind:cardText="cardFace"/>
  </button>
</template>

<script>
import StudyCard from './StudyCard.vue';
export default {
  components: { StudyCard },
  data() {
    return {
      clickNum: 0,
      index: 0,
    };
  },
  props: {
    cardDeck: Array,
  },
  methods: {
    handleClick() {
      this.clickNum++;
      if (this.clickNum === 2) {
        this.index++;
        this.clickNum = 0;
      }
    },
  },
  computed: {
    cardFace() {
      if (this.cardDeck.length <= 0) {
        return "loading"
      }
      if (this.clickNum === 0) {
        return this.cardDeck[this.index].frontText;
      } else if (this.clickNum === 1) {
        return this.cardDeck[this.index].backText;
      }
      return "ARE YOU HAPPY COMPILER?!?!?!?!"
    },
  },
};
</script>

<style>
</style>