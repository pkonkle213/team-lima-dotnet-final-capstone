<template>
    <div class="leftBar">
        <p id="create-card-txt">Add a new card to this deck<p>
        <textarea
         placeholder="Enter text here"
         id="frontCard"
         class="frontCard"
         v-bind:class="{'backCard': clickCounter===1}"
         ref="newcard"
         type="text"
         name="cardName"
         v-model="text"
         v-on:keydown.enter.prevent="saveCard()">
        </textarea>
        <div>
            <button id="newCardButton" type="submit" v-on:click.prevent="saveCard()"> {{ buttonText }} </button>
        </div>
    </div>
</template>


<script>
import FlashCardService from '../services/FlashCardService.js';
export default {
    data() {
        return {
            card: {
                //We need to add the card id? $store.deck.length?
                frontText: "",
                backText: "",
                deckId: +this.$route.params.deckId,
            },
            clickCounter: 0,
            text: "",
        }
    },
    computed: {
        buttonText() {
            if (this.clickCounter === 0) {
                return "Type question";
            } else if (this.clickCounter === 1) {
                return "Click to submit!";
            }
            return "test";
        },
        placeHolderText() {
            if (this.clickCounter === 0) {
                return "Enter answer";
            } else if (this.clickCounter === 1) {
                return "Enter back text!";
            } 
            return "test";
        },
    },
    methods: {
        saveCard() {
            if (this.clickCounter === 0) {
                this.card.frontText = this.text;
                this.text = "";
                this.clickCounter++;
            } else if (this.clickCounter === 1) {
                this.card.backText = this.text;

                FlashCardService.addNewCard(this.card.deckId, this.card).then(response => {
                    console.log(response);
                    this.$store.commit("ADD_CARD", response.data);
                })

                .catch(error => {
                    console.error(error.data);
                })

                this.text = "";
                this.clickCounter = 0;
                this.card.frontText = "";
                this.card.backText = "";
            }
        }
    },
}
</script>


<style lang="scss">
@import '../styles/colors.scss';

#newCardButton {
    width: 380px;
    height: 40px;
    background: linear-gradient(#eb5e00 10%, #ff9011 50%);
    color: white;
    border: solid 1px #c44e00;
    border-radius: 5px;
    box-shadow: 0 2px 5px 0 #af4600;
    text-align: center;
    margin: 10px 0 0 10px;
}

#create-card-txt {
    color: black;
    font-size: 20px;
}

#newCardButton:hover {
    text-shadow:
      0 0 7px #fff,
      0 0 10px #fff,
      0 0 21px #fff,
      0 0 25px #fff, 
      0 0 30px #fff; 
}

//are we using # or . frontCard?
#frontCard {
    padding-top: 75px;
    resize: none;
    text-align: center;
    align-items: center;
    font-size: 30px;
    background-color: rgb(252, 251, 248);
    border: 1px solid rgb(32, 28, 27);
    border-radius: 7px;
    width: 380px;
    height: 200px;
    margin: 20px 10px 10px 10px;
}

#frontCard::placeholder {
    color: rgb(192, 192, 192);
}

.frontCard {
    padding-top: 30px;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: rgb(252, 251, 248);
    box-shadow: 0 0 10px 0 rgb(80, 80, 80);
    border: 1px solid rgb(32, 28, 27);
    border-radius: 2px;
    width: 380px;
    height: 300px;
    margin: 10px 10px 10px 10px;
    resize: none;
}

.backCard {
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: rgb(252, 251, 248);
    box-shadow: 0 0 10px 0 rgb(194, 49, 13);
    border: 1px solid rgb(32, 28, 27);
    border-radius: 7px;
    width: 380px;
    height: 300px;
    margin: 10px 10px 10px 10px;
    resize: none;
}

.leftBar {
    text-align: center;
    margin-top: 10px;
    font-size: 18px;
}

</style>