﻿using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IFlashCardDAO
    {
        List<FlashCard> GetAllFlashCards();

        FlashCard AddNewCard(int deckId, FlashCard cardToAdd, int userId);

        IEnumerable<FlashCard> GetFlashCardsFromDeck(int deckId, int userId);
    }
}