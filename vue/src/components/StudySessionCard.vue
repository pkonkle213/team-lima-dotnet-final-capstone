<template>
  <section>
    <!-- Show the front if the card isn't answered   -->
    <div class="frontFace" v-if="showFront">
        <p>{{$store.state.activeDeck[index].frontText}}</p>
        <button class="button" v-on:click.prevent="flipCard">Answer</button>
    </div>

    <!-- Once the button is clicked, the answer should show, the user should have
    the option of marking the card as right or wrong -->
    <div class="backSide" v-if="!showFront">
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
        }
    },
    methods: {
        flipCard() {
            this.showFront=false;
        },
        rightAnswer() {
            this.$store.state.numCorrect+=1;
            this.showFront=true;
            this.index+=1;
            console.log("Great job! You're so smart",this.$store.state.numCorrect);
        },
        wrongAnswer() {
            this.$store.state.numIncorrect+=1;
            this.showFront=true;
            this.index+=1;
            console.log("Haha, you idiot.",this.$store.state.numIncorrect);
        },
    }
}
</script>

<style>
.frontFace {
    border: black solid 2px;
    width: 80%;
    text-align: center;
}

</style>