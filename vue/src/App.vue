<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app">
    <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link
      id="log"
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
      <router-link class="nav-item" v-bind:to="{ name: 'home' }"
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

body {
  background-color: #f7ebe5;
}

#nav {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  justify-items: center;
  align-items: center;
  background: linear-gradient(#eb5e00 10%, #ff9011 80%);
  color: #c7d5e0;
  text-align: center;
}

.nav-item {
  text-decoration: none;
  font-size: 1.5rem;
  margin: 30px;
  text-align: center;
}

h3 {
  background-color: blue;
  font-size: 2rem;
  color: blue;
  margin: 0px;
  width: 20px;
  height: 150px;
}

#pipe-left {
  justify-self: end;
}

#pipe-right {
  justify-self: start;
}

#log {
  justify-self: end;
}

#view-decks {
  justify-self: start;
}

.content {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>