<template>
  <div class="timer-main">
    {{ countDown }}
  </div>
</template>


<script>
export default {
  data() {
      return {
          countDown: 10
      }
  },
  methods: {
      countDowntimer() {
          if(this.countDown === 0) {

              this.countDown = "Time's up!"
          }
          else {
              setTimeout(() => {
                  this.countDown -= 1,
                  this.countDowntimer()
              }, 1000)
          }
          
      }
  },
  mounted() {
      this.countDowntimer()
  }
};
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap');

.timer-main {
  font-family: 'Press Start 2P', cursive;
  font-size: 50px;
  color: orangered;
}

</style>
