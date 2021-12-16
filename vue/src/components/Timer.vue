<template>
<div>
    <h3>Time Remaining</h3>
    <p id="countdown" ref="countdown"></p>
</div>
</template>

<script>
export default {
    methods: {
        updateCountdown() {
            const seconds = 30;
            let count
            time--;
            this.countdown = this.$refs.countdown.innerText;
            }
        }
    }

</script>

<style>
body {
    background-color: black;
    font-family: 'Roboto', sans-serif;
    margin: 0;
}

#countdown {
    background-color: white;
    display: inline-flex;
    font-size: 50px;
    justify-content: center;
    height: 70px;
    width: 200px;
    margin: 0;
}
</style>