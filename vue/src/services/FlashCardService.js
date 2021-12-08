import axios from 'axios';

export default {
    fetchDeck(deckId) {
      return axios.get(`/FlashCard/${deckId}`)
    },
<<<<<<< HEAD

    addNewCard(deckId, card) {
      return axios.post(`/FlashCard/deck/${deckId}`, card)
    },

    addNewDeck() {
      return axios.post(``)
=======
    addCard(Card) {
      return axios.post(`/FlashCard/deck/`,Card)
>>>>>>> 1c72a1a9a4042bf6c53fcc698268868ce80edee1
    }
}
