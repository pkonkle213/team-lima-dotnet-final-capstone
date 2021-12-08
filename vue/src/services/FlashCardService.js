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

<<<<<<< HEAD
    addNewDeck(newDeck) {
      return axios.post(`/Deck`, newDeck)
    },

=======
    addNewDeck() {
      return axios.post(``)
    }
>>>>>>> 78bd4101eef2cccbc787d93eeb43863d71049e39
}
