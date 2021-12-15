<template>
    <div id="checkBox">
        <router-link v-bind:to="{ name: 'StudySession' }" id="start">Study Deck</router-link>
        <label id="randomizeLabel" for="checkbox">Randomize Cards</label>
        <input type="checkbox" id="randomize" v-on:click.prevent="random()">>
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

<style lang="scss">
@import '../styles/colors.scss';

#checkBox {
    display: grid;
    grid-template-areas: 
    "studyDeck brain";
}

#randomizeLabel {
 color: white;
}

</style>