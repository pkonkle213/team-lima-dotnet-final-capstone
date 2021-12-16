<template>

  <div id="study-session-main">
    <div id="left-side-bar-empty"></div>
    <study-session-card id="session" />
    <timer v-show="this.$store.state.lightningSession" id="timer" />
    <img src="../img/cropped_brain.jpg" id="pic">
  </div>
</template>

<script>
import StudySessionCard from "../components/StudySessionCard.vue";
import Timer from "../components/Timer.vue";

export default {
  components: {
    StudySessionCard,
    Timer,
  },
};
</script>

<style>
#study-session-main {
  display: grid;
  grid-template-columns: 25vw 50vw 25vw;
  height: 100%;
  grid-template-areas: "leftBar session timer";
}

#session {
  grid-area: session;
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-content: center;
  justify-content: flex-start;
  padding-top: 90px;
}

#timer {
  grid-area: timer;
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  padding-top: 90px;
  background: linear-gradient(#e6e6e6 10%, #ffffff 50%);
}

#left-side-bar-empty {
  height: 100%;
  width: 100%;
  grid-area: leftBar;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: flex-start;
  padding-top: 90px;
  background: linear-gradient(#e6e6e6 10%, #ffffff 50%);
}

#pic {
  grid-area: leftBar;
  width: 200px;
}
</style>