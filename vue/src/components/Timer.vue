<template>
  <div id="countdown">
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
#countdown {
  display: flex;
  font-size: 18px;
  justify-content: center;
  justify-self: center;
  padding-top: 20px;
  text-align: center;
  height: 70px;
  width: 200px;
  margin: 0;
}
</style>