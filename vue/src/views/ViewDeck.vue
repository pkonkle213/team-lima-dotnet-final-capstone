<template>
<div id="card-list">
  <study-card v-for="card of $store.state.activeDeck" v-bind:key="card.id" v-bind:card="card"/>
  
  <create-card-view />
</div>
</template>

<script>
import StudyCard from '../components/StudyCard.vue'
import FlashCardService from '../services/FlashCardService.js'
import CreateCardView from '../views/CreateCardView.vue'
export default {
  components: { StudyCard, CreateCardView },
    
    created() {
        FlashCardService
        .fetchDeck(this.$route.params.deckId)
        .then(response => {
            this.$store.commit("SET_ACTIVE_DECK", response.data)
        })
        .catch(error => {
            console.error(error)
        })
    }
}
</script>

<style>

#card-list {
  display: flex;
  margin: 1rem;
  
}

</style>