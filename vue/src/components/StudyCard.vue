<template>
  <div id="test" v-on:mouseover="showButton()" v-on:mouseleave="hideButton()">
    <article class="aCard">
      <div ref="question" class="question">
        <span id="questionText" ref="qText" contenteditable="true" v-on:blur="changeCard()" v-on:keyup="resizeText(questionText, questionBox)">{{ card.frontText }}</span>
      </div>

      <div ref="answer" class="answer">
        <span id="answerText" ref="aText" contenteditable="true" v-on:blur="changeCard()" v-on:keyup="resizeText(answerText, answerBox)">{{ card.backText }}</span>
      </div>
    </article>

    <button id="delete-btn" v-on:click.prevent="deleteCard()" v-show="displayButton"/>
  </div>
</template>


<script>
import FlashCardService from "../services/FlashCardService.js";
export default {
  components: FlashCardService,
  props: {
    card: Object,
    clickNum: Number,
  },
  data() {
    return {
      questionText: Element,
      questionBox: Element,
      answerText: Element,
      answerBox: Element,
      displayButton: false,
    };
  },
  mounted() {
    this.questionBox = this.$refs.question;
    this.questionText = this.$refs.qText;
    this.answerBox = this.$refs.answer;
    this.answerText = this.$refs.aText;
    this.resizeText(this.questionText, this.questionBox);
    this.resizeText(this.answerText, this.answerBox);
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
      this.card.frontText = this.$refs.qText.innerText;
      this.card.backText = this.$refs.aText.innerText;
      FlashCardService.modifyCard(this.card)
        .then((response) => {
          this.$store.commit("UPDATE_CARD", response.data);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    deleteCard() {
      FlashCardService.deleteCard(this.card.id)
        .then((response) => {
          {
            console.log(response);
            this.$store.commit("DELETE_CARD", this.card.id);
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
    adjustQuestionTextArea() {
      let textQArea = this.$refs.qText;
      textQArea.style.fontSize = textQArea.clientHeight / 3 + "px";

      let textAArea = this.$refs.aText;
      textAArea.style.fontSize = textAArea.style.height / 2 + "px";
    },
    resizeText(element, parent) {
      function isOverflown(element) {
        return (
          element.scrollHeight > element.clientHeight ||
          element.scrollWidth > element.clientWidth
        );
      }

      let i = 12;
      let overflow = false;
      let maxSize = 30;

      while (!overflow && i < maxSize) {
        element.style.fontSize = `${i}px`;
        overflow = isOverflown(parent);
        if (!overflow) i++;
      }

      element.style.fontSize = `${i - 1}px`;
      // element.style.height = "100%"
    },
    showButton() {
      this.displayButton = true
    },
    hideButton() {
      this.displayButton = false
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
@import "../styles/colors.scss";

#test {
  display: flex;
  flex-direction: column;
  align-items: center;
  height: 390px;
}

#test:hover {
  cursor: pointer;
}

#delete-btn {
  margin-bottom: 10px;
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

.aCard:hover {
  cursor: text;
}

.question {
  height: 100px;
  display: flex;
  justify-content: center;
  align-items: flex-start;
  background: linear-gradient(#a780a6 10%, #885486 50%);
}

#questionText {
  border: none;
  resize: none;
  outline: none;
  overflow-y: hidden;
  overflow-x: hidden;
  text-align: center;
  color: $questionText;
}

.answer {
  height: 240px;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: $answerBg;
}

#answerText {
  border: none;
  resize: none;
  outline: none;
  overflow-y: hidden;
  overflow-x: hidden;
  width: 100%;
  text-align: center;
  color: $answerText;
  filter: blur(9px);
  background-color: $answerBg;
  z-index: 1;
}

.aCard:hover #answerText {
  filter: none;
}
</style>