<template>
  <button class="card" v-on:click.prevent="handleClick()">
    <h2 class="card-text">{{cardText}}</h2>
  </button>
</template>

<script>
export default {
  data() {
    return {
      showFront: true,
    };
  },
  props: {
    card: Object,
    clickNum: Number,
  },
  methods: {
    handleClick() {
      if (this.showFront) {
        this.showFront = false;
      }
      else if (!this.showFront) {
        this.showFront = true;
      }
    }
  },
  computed: {
    cardText() {
      if (this.showFront) {
        return this.card.frontText
      }
      else if (!this.showFront) {
        return this.card.backText
      }
      return "";
    }
  }
};
</script>

<style>
.card {
  display: flex;
  justify-content: center;
  align-items: center;
  border: 5px solid green;
  border-radius: 10px;
  width: 200px;
  height: 350px;
  margin: 10px 10px 10px 10px;
}


</style>