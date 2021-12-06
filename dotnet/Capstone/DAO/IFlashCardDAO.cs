using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IFlashCardDAO
    {
        List<FlashCard> GetAllFlashCards();

        FlashCard AddNewCard(int userId, FlashCard cardToAdd);
    }
}