import axios from 'axios';

export default {
    fetchMyDecks() {
      return axios.get(`/Deck`)
    },

    fetchDeck(deckId) {
      return axios.get(`/FlashCard/deck/${deckId}`)
    },

    addNewCard(deckId, card) {
      return axios.post(`/FlashCard/deck/${deckId}`, card)
    },

    addNewDeck(newDeck) {
      return axios.post(`/Deck`, newDeck)
    },

}
