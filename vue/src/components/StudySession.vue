<template>
    <!-- Display the front but on click it toggles to the back (and then front again) -->
    <study-card v-bind:card="card"/>
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
    card() {
      if (this.cardDeck.length <= 0) {
        let message = {
          frontText: "loading...",
          backText: "loading..."
        }
        return message
      }
      if (this.clickNum === 0) {
        return this.cardDeck[this.index]
      } else if (this.clickNum === 1) {
        return this.cardDeck[this.index]
      }
      return "ARE YOU HAPPY COMPILER?!?!?!?!"
    },
  },
};
</script>


<style lang="scss">
@import '../styles/colors.scss';

 .card-btn {
  display: inline-block;
  padding: 0;
  background: none;
  outline: none;
  border: none;
}
</style>