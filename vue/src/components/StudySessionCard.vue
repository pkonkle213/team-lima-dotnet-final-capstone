<template>
  <section class="card">
    <!-- Show the front if the card isn't answered   -->
    <div v-if="showFront">
        <p>{{$store.state.activeDeck[index].frontText}}</p>
        <button class="button" v-on:click.prevent="flipCard">Answer</button>
    </div>

    <!-- Once the button is clicked, the answer should show, the user should have
    the option of marking the card as right or wrong -->
    <div v-if="!showFront">
        <p>Answer: {{$store.state.activeDeck[index].backText}}</p>
        <p>Did you get the answer right?</p>
        <button v-on:click.prevent="rightAnswer">Yes</button>
        <button v-on:click.prevent="wrongAnswer">No</button>
    </div>

    <!-- After selecting if right, store data for how many they got right (# and %)
    and progress to the next question -->
  </section>
</template>

<script>
export default {
    data() {
        return {
            showFront: true,
            index: 0,
            numCorrect: 0,
            numIncorrect: 0
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
            this.index=0;
            console.log("Correct: ",this.numCorrect);
            console.log("Incorrect: ",this.numIncorrect);
            this.numCorrect=0,
            this.numIncorrect=0
        }
    },
}
</script>

<style>
.card {
    border: black solid 2px;
    width: 50%;
    text-align: center;
    padding: 2rem;
    margin: 2rem;
}

</style>