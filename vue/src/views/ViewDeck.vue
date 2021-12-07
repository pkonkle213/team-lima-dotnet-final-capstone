<template>
  <section>
    <h2>This is a card</h2>
    <p>This would be the front of the card</p>
    <p>This would be the back of the card</p>
    <!-- Call the study card component with specific information -->

    <study-card />

  </section>
</template>

<script>
import StudyCard from '../components/StudyCard.vue'

export default {
    components: {
        StudyCard,
    },
    data() {
        return {
            cardDeck: []
        }
    },
    created() {

    }
}
</script>

<style>

</style>