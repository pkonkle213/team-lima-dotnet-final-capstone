import axios from 'axios';

export default {
    fetchDeck(deckId) {
        return axios.get(`/FlashCard/${deckId}`)
      },
}
