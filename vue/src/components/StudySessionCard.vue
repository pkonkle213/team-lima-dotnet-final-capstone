<template>
  <section class="studysession">
    <!-- Show the front if the card isn't answered   -->
    <div class="card">
      <div id="test-test" v-if="showFront && !IsDone">
        <span>
          <b>Question {{ index + 1 }}: </b>
          {{ $store.state.activeDeck[index].frontText }}
        </span>
      </div>
      <button v-if="showFront && !IsDone" id="answer" class="button" v-on:click.prevent="flipCard">
        Answer
      </button>

      <!-- Once the button is clicked, the answer should show, the user should have
        the option of marking the card as right or wrong -->
      <div id="answerResult" v-if="!showFront && !IsDone">
        <p><b>Answer:</b> {{ $store.state.activeDeck[index].backText }}</p>
        <p>Did you get the answer right?</p>
        <!-- After selecting if right, store data for how many they got right (# and %)
            and progress to the next question -->
        <button id="yes" v-on:click.prevent="rightAnswer()">Yes</button>
        <button id="no" v-on:click.prevent="wrongAnswer()">No</button>
      </div>

      <div v-if="IsDone">
        <h4>Welcome to the end!</h4>

        <p v-if="this.numCorrect > 0">
          You got {{ this.numCorrect }} question {{this.numCorrect === 1 ? "" : "s"}} correct
        </p>

        <p v-if="this.numIncorrect > 0">
          You got {{ this.numIncorrect }} question {{ this.numIncorrect === 1 ? "" : "s"}} incorrect
        </p>

        <p v-if="this.numCorrect + this.numIncorrect != 0">
          For a percentage of {{((this.numCorrect / (this.numCorrect + this.numIncorrect)) * 100).toFixed(2)}}%!
        </p>

        <div class="doneScreen">
          <div v-for="n in this.listCorrect" v-bind:key="n">
            <div v-if="n" class="right"/>
            <div v-if="!n" class="wrong"/>
          </div>
          <!-- <div class="box right" v-for="n in this.numCorrect" v-bind:key="n"></div>
                <div class="box wrong" v-for="n in this.numIncorrect" v-bind:key="n"></div> -->
        </div>
        <div/>
      </div>
    </div>

    <button id="endEarly" v-on:click.prevent="done()" v-if="!IsDone">
      End Session?
    </button>

    <button id="backToDeck" v-if="IsDone" class="button" v-on:click="goToDeck()">
      Return to deck
    </button>

  </section>
</template>

<script>
export default {
  data() {
    return {
      showFront: true,
      index: 0,
      listCorrect: [],
      numCorrect: 0,
      numIncorrect: 0,
      IsDone: false,
    };
  },
  methods: {
    flipCard() {
      this.showFront = false;
    },
    rightAnswer() {
      this.numCorrect += 1;
      this.listCorrect.push(true);
      this.showFront = true;
      this.index += 1;
      if (this.$store.state.activeDeck.length === this.index) {
        this.done();
      }
    },
    wrongAnswer() {
      this.numIncorrect += 1;
      this.listCorrect.push(false);
      this.showFront = true;
      this.index += 1;
      if (this.$store.state.activeDeck.length === this.index) {
        this.done();
      }
    },
    done() {
      this.IsDone = true;
    },
    goToDeck() {
      this.$store.state.activeDeck = [];
      this.$router.back();
    },
  },
};
</script>


<style lang="scss">
@import "../styles/colors.scss";

// #test-test {
//   display: flex;
//   flex-direction: column;
//   align-items: center;
// }

#answer {
  display: flex;
  // margin-top: 10px;
  // margin-bottom: 7%;
  width: 110px;
  height: 50px;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  color: white;
  border: solid 1px #c44e00;
  border-radius: 7%;
  box-shadow: 0 2px 5px 0 #af4600;
  justify-content: center;
  align-items: center;
  justify-self: flex-end;
  // grid-area: answer;
}

#backToDeck {
  display: flex;
  flex-direction: columns;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  color: white;
  border: solid 1px #c44e00;
  border-radius: 7%;
  box-shadow: 0 2px 5px 0 #af4600;
  margin-top: 20px;
}

#answer:hover {
  text-shadow: 0 0 7px #fff, 0 0 10px #fff, 0 0 21px #fff, 0 0 25px #fff,
    0 0 30px #fff;
}

.studysession {
  height: 100%;
  width: 100%;
  text-align: center;
  font-size: 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.card {
  display: flex;
  flex-direction: column;
  min-width: 100%;
  height: 30%;
  border: #ffffff solid 3px;
  text-align: center;
  border-radius: 7px;
  align-items: center;
  gap: 20px;
}

.right {
  border: solid 2px;
  background-color: #dbecac;
  width: 20px;
  height: 20px;
}

#yes {
  margin-top: 10px;
  margin-right: 7px;
  width: 50px;
  height: 30px;
  background: linear-gradient(#00b300 10%, #00fa00 50%);
  color: white;
  border: solid 1px #006800;
  border-radius: 7%;
  box-shadow: 0 2px 5px 0 #797979;
  cursor: pointer;
}

#yes:hover {
  text-shadow: 0 0 7px #fff, 0 0 10px #fff, 0 0 21px #fff, 0 0 25px #fff,
    0 0 30px #fff;
}

#no:hover {
  cursor: grab, pointer;
  text-shadow: 0 0 7px #fff, 0 0 10px #fff, 0 0 21px #fff, 0 0 25px #fff,
    0 0 30px #fff;
}

#no {
  margin-top: 10px;
  margin-left: 7px;
  width: 50px;
  height: 30px;
  background: linear-gradient(#a70000 10%, #fa0000 50%);
  color: white;
  border: solid 1px #550000;
  border-radius: 7%;
  box-shadow: 0 2px 5px 0 #797979;
  cursor: pointer;
}

.wrong {
  border: solid 2px;
  background-color: #bb222f;
  width: 20px;
  height: 20px;
}

.doneScreen {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

#endEarly {
  width: 140px;
  height: 50px;

  background: linear-gradient(#757575 10%, #bdbdbd 50%);
  color: white;
  border: solid 1px #464646;
  border-radius: 5px;
  box-shadow: 0 2px 5px 0 #555555;
}

#endEarly:hover {
  text-shadow: 0 0 7px #fff, 0 0 10px #fff, 0 0 21px #fff, 0 0 25px #fff,
    0 0 30px #fff;
}
</style>