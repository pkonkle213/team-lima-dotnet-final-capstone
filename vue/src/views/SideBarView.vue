<template>
  <div id="side-bar">
      <create-card-view />

  </div>
</template>

<script>
import CreateCardView from './CreateCardView.vue'
export default {
  components: { CreateCardView },

}
</script>

<style>
#side-bar {
  display: flex;
  flex-direction: column;
  gap: 100px;

  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-areas: 
  "start pic";
}

#start {
  color: white;
  background: linear-gradient(#eb5e00 10%, #ff9011 50%);
  border: solid 1px #c44e00;
  border-radius: 4%;
  width: 200px;
  height: 100px;

  grid-template-areas: start;
  text-decoration: none;
  color: rgb(255, 255, 255);
  font-size: 30px;
  text-align: center;
  border: solid black 1px;
  padding: 24px 10px 3px 10px;
  border-radius: 5px;
}

#start:hover {
  text-shadow:
  0 0 7px #fff,
  0 0 10px #fff,
  0 0 21px #fff,
  0 0 25px #fff, 
  0 0 30px #fff; 
}

#brainThink {
  grid-template-areas: pic;
  height: 100px;
  width: auto;
}

</style>
/* #side-bar {
  display: flex;
  flex-direction: column;
  gap: 100px;
} */
