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
  background-color: rgb(252, 251, 248);
  box-shadow: 0 0 10px 0 rgb(32, 28, 27);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 180px;
  height: 100px;
  margin: 10px 10px 10px 10px;
}

</style>