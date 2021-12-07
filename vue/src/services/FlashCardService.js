import axios from 'axios';

export default {
    fetchDeck() {
        return axios.get('api/FlashCard')
      },
}
