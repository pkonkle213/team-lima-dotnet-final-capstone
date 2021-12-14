<template>
  <div id="test">
    <article class="aCard">
      <div ref="quest" class="question">
        <span id="questionText" ref="qText" contenteditable="true" v-on:change.prevent="changeCard(); adjustQuestionTextArea()">{{card.frontText}}</span>
      </div>
      <div class="answer">
        <textarea ref="aText" id="answerText" v-model="card.backText" v-on:change.prevent="changeCard()"></v-model></textarea>
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

    let element = this.$refs.qText;
    let parent = this.$refs.quest;
    function isOverflown(element) {
      return element.scrollHeight > element.clientHeight || element.scrollWidth > element.clientWidth;
    }
    const resizeText = ({element, parent}) => {
      let i = 12
      let overflow = false

      while(!overflow) {
        element.style.fontSize =`${i}px`
        overflow = isOverflown(parent)
        if(!overflow) i++
      }

      element.style.fontSize = `${i -1}px`
    }
    resizeText({element, parent})




      // let textQArea = this.$refs.qText;
      // textQArea.style.height = (textQArea.scrollHeight)+"px"
      // textQArea.style.fontSize = (textQArea.clientHeight/3)+"px"

      // let textAArea = this.$refs.aText;
      // textAArea.style.height = (textAArea.scrollHeight)+"px"
      // textAArea.style.fontSize = (textAArea.clientHeight/3)+"px"


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
    },
    adjustQuestionTextArea() {

      let textQArea = this.$refs.qText;
       textQArea.style.fontSize = (textQArea.clientHeight/3)+"px";
       

      let textAArea = this.$refs.aText;
      textAArea.style.fontSize = (textAArea.style.height/2)+"px"
    
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
  border: black solid 1px;
  border-radius: 0.5rem;
  margin: 0.5rem;
  overflow: hidden;
  width: 380px;
  height: 300px;
}

.question {
  height: 30px;
  display: flex;
  justify-content: center;
  align-items: flex-start;
  flex-grow: 1;
  background-color: $questionBg;
}

#questionText {
  border: none;
  resize: none;
  outline: none;
  overflow-y: hidden;
  overflow-x: hidden;
  text-align: center;
  background-color: $questionBg;
  color: $questionText;
  width: 100%;
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
  overflow-y: hidden;
  overflow-x: hidden;
  width: 100%;
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
} 
</style>