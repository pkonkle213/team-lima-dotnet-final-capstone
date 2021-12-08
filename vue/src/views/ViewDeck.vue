<template>
<div>
  <study-card v-for="card of deck" v-bind:key="card.id" v-bind:card="card"/>
</div>
</template>

<script>
import StudyCard from '../components/StudyCard.vue'
import FlashCardService from '../services/FlashCardService'
export default {
  components: { StudyCard },
    data() {
        return {
            deck: [],
        }
    },
    created() {
        FlashCardService
        .fetchDeck(this.$route.params.deckId)
        .then(response => {
            this.deck = response.data
        })
        .catch(error => {
            console.error(error)
        })
    }
}
</script>

<style>

</style>