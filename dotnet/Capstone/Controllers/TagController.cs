using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagDAO tagDAO;

        public TagController(ITagDAO tagDAO)
        {
            this.tagDAO = tagDAO;
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
        /// A get request to fetch any flashcard in the database for the logged in user which relates to the keyword input in the search bar.
        /// The keyword will come to the controller as a string and will attempt to find matches in the database associated with tags that match flashcards in their account.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        [HttpGet("tag/{tagName}")]
        public ActionResult SearchCardsUsingTag(string tagName)
        {
            int userId = GetCurrentUserID();
            tagDAO.SearchCardsUsingTag(tagName, userId);
        }
    }
}
