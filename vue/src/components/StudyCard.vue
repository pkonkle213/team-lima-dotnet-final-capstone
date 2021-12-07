<template>
  <section>
      <!-- Display the front but on click it toggles to the back (and then front again) -->
    <p> {{ card.FrontText }}</p>
    <p> {{ card.BackText }}</p>
  </section>
</template>

<script>
export default {
    props: {
        card: Object,
    }
}
</script>

<style>

</style>