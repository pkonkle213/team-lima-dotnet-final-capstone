import axios from 'axios';

export default {
    fetchDeck(deckId) {
        return axios.get(`/FlashCard/deck/${deckId}`)
      },
    fetchMyDecks() {
      return axios.get(`/Deck`)
    },

    addNewCard(deckId, card) {
      return axios.post(`/FlashCard/deck/${deckId}`, card)
    }

}
