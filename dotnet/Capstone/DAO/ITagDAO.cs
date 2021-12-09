using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface ITagDAO
    {
        public IEnumerable<FlashCard> SearchCardsUsingTag(string tag, int userId);
    }
}
