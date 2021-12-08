using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {

        private readonly IDeckDAO deckDAO;
        public DeckController(IDeckDAO deckDAO)
        {
            this.deckDAO = deckDAO;
        }

        /// <summary>
        /// Gets the current logged in user's ID to use elsewhere.
        /// </summary>
        /// <returns></returns>
        private int GetCurrentUserID()
        {
            var user = this.User;
            int id = 0;
            if (user.Identity.Name != null)
            {
                var idClaim = user.FindFirst("sub");
                string idString = idClaim.Value;
                id = int.Parse(idString);
            }
            return id;
        }

        /// <summary>
        /// Gets all of the user's decks for their account. Because the user id is specific to the current logged in user, the decks viewed are specific to ONLY the authorized user's account.
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public ActionResult<List<Deck>> GetAllDecks()
        {
            int userId = GetCurrentUserID();

            List<Deck> results = deckDAO.GetAllDecks(userId);
            return Ok(results);
        }
    }
}
