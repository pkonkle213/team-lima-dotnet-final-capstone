<template>
    <div>
        <router-link v-bind:to="{ name: 'StudySession' }" id="start">Study Deck</router-link>
        <button v-on:click.prevent="random()">Randomize the order of the cards</button>
    </div>
</template>

<script>
export default {
    methods: {
        random() {
            let maxIndex = this.$store.state.activeDeck.length;
            for(let a=0; a < maxIndex; a++) {
                let randomIndex = Math.floor(Math.random()*maxIndex);
                let randomIndexSwap = Math.floor(Math.random()*maxIndex);
                let substitute = this.$store.state.activeDeck[randomIndex];
                this.$store.state.activeDeck[randomIndex] = this.$store.state.activeDeck[randomIndexSwap];
                this.$store.state.activeDeck[randomIndexSwap] = substitute;
            }
        },
    },
}
</script>

<style>

</style>