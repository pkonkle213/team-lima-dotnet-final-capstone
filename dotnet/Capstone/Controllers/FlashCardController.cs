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
    public class FlashCardController : ControllerBase
    {
        private readonly IFlashCardDAO flashCardDAO;
        public FlashCardController(IFlashCardDAO flashCardDAO)
        {
            this.flashCardDAO = flashCardDAO;
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
        [AllowAnonymous]
        public ActionResult GetFlashCardsFromDeck(int deckId)
        {
            IEnumerable<FlashCard> results = flashCardDAO.GetFlashCardsFromDeck(deckId);
            return Ok(results);
        }

        [HttpPost("deck/{deckId}")]
        public ActionResult AddNewCard(int deckId, FlashCard cardToAdd)
        {
            FlashCard addCard = flashCardDAO.AddNewCard(deckId, cardToAdd);
            return Ok();
        }


    }
}
