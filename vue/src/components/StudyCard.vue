<template>
  <div class="card">
    <span class="cardText">{{ cardText }}</span>
  </div>
</template>

<script>
export default {
  props: {
    cardText: String,
  }
}
</script>

<style>

.card {
  border-color: green;
  border-width: thick;
  margin-top: 2rem;
  padding-top: 30%;
  padding-bottom: 30%
}
.cardText {
  display: block;
  text-align: center;
}

</style>