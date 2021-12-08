using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FlashCardController : ControllerBase
    {
        private readonly IFlashCardDAO flashCardDAO;
        public FlashCardController(IFlashCardDAO flashCardDAO)
        {
            this.flashCardDAO = flashCardDAO;
        }

        // Consider creating a static method!
        /// <summary>
        /// Gets the current logged in user's ID
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAllFlashCards()
        {
            IEnumerable<FlashCard> results = flashCardDAO.GetAllFlashCards();
            return Ok(results);
        }

        /// <summary>
        /// Get all flashcards specific to a certain deck
        /// </summary>
        /// <returns></returns>
        [HttpGet("deck/{deckId}")]
        public ActionResult GetFlashCardsFromDeck(int deckId)
        {
            int userId = GetCurrentUserID();
            IEnumerable<FlashCard> results = flashCardDAO.GetFlashCardsFromDeck(deckId);
            if (results != null)
            {
                return Ok(results);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("deck/{deckId}")]
        public ActionResult AddNewCard(int deckId, FlashCard cardToAdd)
        {
            int userId = GetCurrentUserID();
            FlashCard addCard = flashCardDAO.AddNewCard(deckId, cardToAdd);
            return Ok(addCard);
        }
    }
}
