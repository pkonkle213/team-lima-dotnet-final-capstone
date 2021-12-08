using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IDeckDAO
    {
        Deck CreateDeck(int userId, Deck newDeck);
        List<Deck> GetAllDecks(int userId);
    }
}
