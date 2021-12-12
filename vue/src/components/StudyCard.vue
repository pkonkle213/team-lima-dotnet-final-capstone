<template>
<div id="test">
  <button ref="cardSize" v-bind:class="{'cardback': showFront===false}" class="card" v-on:click.prevent="handleClick()">
    <!-- <p>{{face}}</p> -->
    <h2 class="card-text">{{cardText}}</h2>
  </button>
</div>
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
  mounted() {
      // let text = this.$refs.cardSize;
      // let 1005  text.value.length;
      // initialSize = initialSize <= 10 ? 10 : initialSize;
      // text.style.fontSize = "x-large";
      // text.style.display="none";
  },
  methods: {
    handleClick() {
      if (this.showFront) {
        this.showFront = false;
      }
      else if (!this.showFront) {
        this.showFront = true;
      }
    },
  },
  computed: {
    face() {
      if (this.showFront) {
        return "Front";
      } else {
        return "Back";
      }
    },
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

#test {
  display: flex;
  flex-direction: row;
}

.card {
  display: inline-flex;
  justify-content: center;
  align-items: center;
  background: rgb(255, 253, 253);
  box-shadow: 0 0 10px 0 rgb(73, 39, 31);
  border: 1px solid rgb(32, 28, 27);
  border-radius: 2px;
  width: 380px;
  height: 200px;
  margin: 10px 10px 10px 10px;
}

.cardback {
  display: flex;
  justify-content: center;
  align-items: center;
  background: rgb(255, 253, 253);
  box-shadow: 0 0 10px 0 rgb(194, 49, 13);
  border: 1px solid rgb(85, 82, 81);
  border-radius: 2px;
  width: 380px;
  height: 200px;
  margin: 10px 10px 10px 10px;
}

</style>