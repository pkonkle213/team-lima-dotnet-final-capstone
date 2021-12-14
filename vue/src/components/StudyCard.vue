<template>
  <div id="test">
    <article class="aCard">
      <div class="question">
        <span id="questionText">{{ card.frontText }}</span>
      </div>
      <div class="answer">
        <span id="answerText">{{ card.backText }}</span>
      </div>
    </article>
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
      } else if (!this.showFront) {
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
        return this.card.frontText;
      } else if (!this.showFront) {
        return this.card.backText;
      }
      return "";
    },
  },
};
</script>

<style lang="scss">
@import '../styles/colors.scss';

#test {
  display: flex;
  flex-direction: row;
}

.aCard {
  display: flex;
  flex-direction: column;
  border: black solid 2px;
  border-radius: 0.5rem;
  margin: 0.5rem;
  overflow: hidden;
  width: 380px;
  height: 300px;
}

.question {
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 20px;
  flex-grow: 1;
  background-color: $questionBg;
}

#questionText {
  color: $questionText;
}

.answer {
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: $answerBg;
  flex-grow: 5;
}

#answerText {
  font-size: 2rem;
  color: $answerText;
  filter: blur(9px);
}

.aCard:hover #answerText {
  filter: none;
} 
</style>