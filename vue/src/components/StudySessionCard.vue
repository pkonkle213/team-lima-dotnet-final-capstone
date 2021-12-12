<template>
  <section>
    <!-- Show the front if the card isn't answered   -->
    <div class="frontFace" v-if="showFront">
        <p>What is the airspeed velocity of an unladen swallow?</p>
        <button class="button">Answer</button>
    </div>

    <!-- Once the button is clicked, the answer should show, the user should have
    the option of marking the card as right or wrong -->
    <div class="backSide" v-if="!showFront">
        <p>Did you get the answer right?</p>
        <button>Yes</button>
        <button>No</button>
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

        }
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