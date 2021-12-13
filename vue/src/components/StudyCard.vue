<template>
  <div id="test">
    <article class="aCard">
      <div class="question">
        <textarea id="questionText" v-model="card.frontText"></v-model></textarea>
        <button v-on:click.prevent="changeCard()">Save Changes</button>
      </div>
      <div class="answer">
        <textarea id="answerText" v-model="card.backText"></v-model></textarea>
        <button id ="testing" v-on:click.prevent="changeCard()">Save Changes</button>
      </div>
    </article>
  </div>
</template>

<script>
import FlashCardService from '../services/FlashCardService.js'

export default {
  components: FlashCardService,
  data() {
    return {
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
    changeCard() {
      FlashCardService.modifyCard(this.card)
      .then(response => {
        this.$store.commit("UPDATE_CARD", response.data)
      })
      .catch(error => {
        console.log(error)
      });
    }
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
  border: black solid 1px;
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
  border: none;
  resize: none;
  outline: none;
  text-align: center;
  background-color: $questionBg;
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
  border: none;
  resize: none;
  outline: none;
  text-align: center;
  font-size: 2rem;
  color: $answerText;
  filter: blur(9px);
  background-color: $answerBg;
  z-index: 1;
}

#testing {
}

.aCard:hover #answerText {
  filter: none;
  cursor: url('../img/Santic.png'), pointer;
} 
</style>