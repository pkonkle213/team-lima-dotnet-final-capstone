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
    [Route("api/[controller]")]
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
        

    }
}
