using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IDeckDAO
    {
        List<Deck> GetAllDecks(int userId);
        bool UserHasAccessToDeck(int userId, int deckId);
    }
}
