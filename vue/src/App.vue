<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template id="all">
  <div id="app">
    <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link
      id="register-btn"
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token"
        >Register</router-link
      >
      <router-link
      id="log"
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token"
      >
        Login
      </router-link>
      <router-link
      id="log"
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token"
      >
        Logout
      </router-link>
      <!--- <h3 id="pipe-left">|</h3> --->
      <router-link id="home" class="nav-item" v-bind:to="{ name: 'home' }"
        >Home</router-link
      >
      <!--- <h3 id="pipe-right">|</h3> --->
      <router-link
        id="view-decks"
        class="nav-item"
        v-bind:to="{ name: 'viewMyDecks' }"
        v-if="$store.state.token"
      >
        View My Decks
      </router-link>
    </div>

    <router-view class="content" />
  </div>
</template>

<script>
export default {};
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">
@import "./styles/colors.scss";

// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import "../node_modules/bootstrap/scss/bootstrap";

// Your custom styles go below this point

#all {
  height: 100vh;

}

body {
  height: 100vh;
  background-color: #ffffff;
}

#app {
  height: 100%;
  display: grid;
  grid-template-columns: 1fr;
  grid-template-rows: 100px 1fr;
  grid-template-areas: 
    "nav"
    "content";
}

#nav {
  grid-area: nav;
  display: grid;
  grid-template-columns: 45vw 9vw 45vw;
  // overflow-x: hidden;
  grid-template-areas: 
    "log home viewDecks";
    position: sticky;
    top: 0;
  justify-items: center;
  align-items: center;
  background: linear-gradient(#eb5e00 10%, #ff9011 80%);
  color: #c7d5e0;
  text-align: center;
  // position: sticky;
  // z-index: 2;
}

#nav a:hover {
    text-decoration: none;
    color: whitesmoke;
    text-shadow:
      0 0 7px #fff,
      0 0 10px #fff,
      0 0 21px #fff,
}

.nav-item {
  text-decoration: none;
  font-size: 1.5rem;
  margin: 30px;
  text-align: center;
  color: whitesmoke;
}

#log {
  grid-area: log;
  justify-self: end;
}

#home {
  grid-area: home;
}

#view-decks {
  grid-area: viewDecks;
  justify-self: start;
}

#register-btn {
  grid-area: viewDecks;
  justify-self: start;
}

.content {
  height: 100%;
  grid-area: content;
  align-self: flex-start;
  display: flex;
  flex-shrink: 1;
  flex-wrap: wrap;
  flex-direction: column;
  align-items: center;
  overflow: hidden;
}

footer {
  grid-area: footer;
  height: 100%;
  background:#6e8fa0
}

#register > form {
  grid-area: content;
}

</style>