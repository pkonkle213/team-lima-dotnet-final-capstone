<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app">
    <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token"
        >Register</router-link
      >
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token"
      >
        Login
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token"
      >
        Logout
      </router-link>
      <h3>|</h3>
      <router-link class="nav-item" v-bind:to="{ name: 'home' }"
        >Home</router-link
      >
      <h3>|</h3>
      <router-link
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
  margin: 5px;
  background-color: #e7dfdb;
}

#nav {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 5%;
  border-bottom: solid 20px blue;
}

.nav-item {
  text-decoration: none;
  font-size: 1.5rem;
}

h3 {
  background-color: blue;
  font-size: 2rem;
  color: blue;
  margin-bottom: 1px;
  width: 20px;
}

.content {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>