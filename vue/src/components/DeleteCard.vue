<template>
  <button id="deleteBtn" v-on:click.prevent="deleteCard()">Delete</button>
</template>

<script>
export default {}
</script>

<style lang="scss">
@import '../styles/colors.scss';

#deleteBtn {
  width: 180px;
  height: 30px;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  color: white;
  border: solid 1px #c44e00;
  border-radius: 5px;
  box-shadow: 0 2px 5px 0 #af4600;
  text-align: center;
  margin: 10px 0 0 10px;
}

</style>