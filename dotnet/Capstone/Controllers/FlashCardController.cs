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
        private readonly IDeckHelperDAO deckHelperDAO;
        public FlashCardController(IFlashCardDAO flashCardDAO, IDeckHelperDAO deckHelperDAO)
        {
            this.flashCardDAO = flashCardDAO;
            this.deckHelperDAO = deckHelperDAO;
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

        /// <summary>
        /// This is primarily for testing purposes in order to check all flashcards.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAllFlashCards()
        {
            IEnumerable<FlashCard> results = flashCardDAO.GetAllFlashCards();
            return Ok(results);
        }

        /// <summary>
        /// Get all flashcards specific to a certain deck. The deck itself will already be associated to a specific user.
        /// To prevent user from selecting any deck id that is not associated, forbidden status code will be sent if not correct user.
        /// </summary>
        /// <returns></returns>
        [HttpGet("deck/{deckId}")]
        public ActionResult GetFlashCardsFromDeck(int deckId) // The specific deck Id selected
        {
            int userId = GetCurrentUserID();
            
            // Checks that the current selected deck is owned by the current user.
            bool userDeck = deckHelperDAO.UserHasAccessToDeck(userId, deckId);

            // Checks that the deck attempting selection exists in the database
            bool deckExists = deckHelperDAO.DeckExists(deckId);

            if (userDeck)
            {
                IEnumerable<FlashCard> results = flashCardDAO.GetFlashCardsFromDeck(deckId, userId); // userId required here so that it limits the deck id by the currently logged in user.
                return Ok(results);
            }
            else if (!deckExists)
            {
                return BadRequest();
            }
            else
            {
                return Forbid();
            }
        }

        /// <summary>
        /// Allows a user to add a new flashcard to a specific deck on their account.
        /// </summary>
        /// <param name="deckId"></param>
        /// <param name="cardToAdd"></param>
        /// <returns></returns>
        [HttpPost("deck/{deckId}")]
        public ActionResult AddNewCard(int deckId, FlashCard cardToAdd)
        {
            int userId = GetCurrentUserID();
            FlashCard addCard = flashCardDAO.AddNewCard(deckId, cardToAdd);
            return Ok(addCard);
        }
    }
}
