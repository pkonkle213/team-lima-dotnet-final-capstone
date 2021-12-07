import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/login/register', user)
  },

 fetchDeck() {
   return axios.get('api/FlashCard')
 },

}
