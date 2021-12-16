<template>
  <div id="timer-main">
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

<style lang="scss">
@import "../styles/colors.scss";

</style>
