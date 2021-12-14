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

    modifyCard(card) {
      return axios.put(`/FlashCard/deck`, card)
    },

    deleteCard(cardId) {
      return axios.delete(`/FlashCard/deck/${cardId}`)
    },

    addNewDeck(newDeck) {
      return axios.post(`/Deck`, newDeck)
    },

    modifyDeck(deck) {
      return axios.put(`/Deck/deck`, deck)
    },

    deleteDeck(deckId) {
      return axios.delete(`Deck/deck/${deckId}`)
    }

}
