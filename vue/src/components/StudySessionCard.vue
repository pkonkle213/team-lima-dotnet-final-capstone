<template>
  <section class="studysession">
    <!-- Show the front if the card isn't answered   -->
    <div class="card">
        <div v-if="showFront && !IsDone">
            <p>Question {{index+1}}: {{$store.state.activeDeck[index].frontText}}</p>
            <button class="button" v-on:click.prevent="flipCard">Answer</button>
        </div>

        <!-- Once the button is clicked, the answer should show, the user should have
        the option of marking the card as right or wrong -->
        <div v-if="!showFront && !IsDone">
            <p>Answer: {{$store.state.activeDeck[index].backText}}</p>
            <p>Did you get the answer right?</p>
            <!-- After selecting if right, store data for how many they got right (# and %)
            and progress to the next question -->
            <button v-on:click.prevent="rightAnswer">Yes</button>
            <button v-on:click.prevent="wrongAnswer">No</button>
        </div>

        <div v-if="IsDone">
            <h4>Welcome to the end!</h4>
            <p v-if="this.numCorrect>0">You got {{this.numCorrect}} question{{this.numCorrect===1 ? "" : "s" }} correct</p>
            <p v-if="this.numIncorrect>0">You got {{this.numIncorrect}} question{{this.numIncorrect===1 ? "" : "s" }} incorrect</p>
        </div>
    </div>

    <button v-on:click.prevent="done" v-if="!IsDone">Would you like to tap out?</button>

  </section>
</template>

<script>
export default {
    data() {
        return {
            showFront: true,
            index: 0,
            numCorrect: 0,
            numIncorrect: 0,
            IsDone: false,
        }
    },
    methods: {
        flipCard() {
            this.showFront=false;
        },
        rightAnswer() {
            this.numCorrect+=1;
            this.showFront=true;
            this.index+=1;
            if (this.$store.state.activeDeck.length===this.index){
                this.done();
            }
        },
        wrongAnswer() {
            this.numIncorrect+=1;
            this.showFront=true;
            this.index+=1;
            if (this.$store.state.activeDeck.length===this.index){
                this.done();
            }
        },
        done() {
            this.IsDone=true;
        }
    },
}
</script>

<style>

.studysession {
    width: 50%;
    text-align: center;
}

.card {
    border: black solid 2px;
    text-align: center;
    padding: 2rem;
    margin: 2rem;
}

</style>