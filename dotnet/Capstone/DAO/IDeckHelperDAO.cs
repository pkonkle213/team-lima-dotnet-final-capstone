using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IDeckHelperDAO
    {
        bool UserHasAccessToDeck(int userId, int deckId);
        public bool DeckExists(int deckId);
    }
}
