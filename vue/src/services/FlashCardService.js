import axios from 'axios';

export default {
    fetchDeck(deckId) {
      return axios.get(`/FlashCard/${deckId}`)
    },
    addCard(Card) {
      return axios.post(`/FlashCard/deck/`,Card)
    }
}
