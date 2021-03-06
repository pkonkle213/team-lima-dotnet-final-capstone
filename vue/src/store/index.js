import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')

let currentUser = null;
if ((localStorage.getItem('user') && localStorage.getItem('user') != 'undefined')) {
  currentUser = JSON.parse(localStorage.getItem('user'));
}

if(currentToken && currentToken != 'undefined') {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {}, // If a user is an admin, their user.role will be 'admin'
    activeDeck: [],
    userDecks: [],
    lightningSession: false,
    activeCard: {
      id: 0,
      frontFace: "",
      backFace: "",
      deckId: 0,
    },
    numCorrect: 0,
    numIncorrect: 0,
  },
  mutations: {
    SET_ACTIVE_CARD(state, payload) {
      state.activeCard = payload;
    },
    ADD_DECK(state, payload) {
      state.userDecks.push(payload);
    },

    MODIFY_DECK(state, payload) {
      let index = state.userDecks.findIndex(deck => deck.id === payload.id)
      state.userDecks[index] = payload
    },

    DELETE_DECK(state, payload) {
      let index = state.userDecks.findIndex(deck => deck.id === payload)
      state.userDecks.splice(index, 1)
    },

    SET_USER_DECKS(state, payload) {
      state.userDecks = payload;
    },

    SET_ACTIVE_DECK(state, payload) {
      state.activeDeck = payload;
    },

    ADD_CARD(state, payload) {
        state.activeDeck.unshift(payload);
    },

    UPDATE_CARD(state, payload) {
      let index = state.activeDeck.findIndex(card => card.id === payload.id)
      state.activeDeck[index] = payload
    },

    DELETE_CARD(state, payload) {
      let index = state.activeDeck.findIndex(card => card.id === payload)
      state.activeDeck.splice(index, 1);
    },

    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    LIGHTNING_ROUND(state, payload) {
      state.lightningSession = payload;
    }
  }
})
