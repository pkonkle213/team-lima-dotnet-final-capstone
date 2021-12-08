import axios from 'axios';

export default {
    fetchDeck(deckId) {
        return axios.get(`/FlashCard/deck/${deckId}`)
      },
    fetchMyDecks() {
      return axios.get(`/Deck`)
    },

}
