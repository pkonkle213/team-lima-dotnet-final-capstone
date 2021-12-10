using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class TagDAO : ITagDAO
    {
        private readonly string connectionString;

        public TagDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Searches the database for any flashcards associated with both the current user, and the keyword (tag) they use to narrow the card search by.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<FlashCard> SearchCardsUsingTag(string tag, int userId)
        {
            List<FlashCard> flashCards = new List<FlashCard>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "SELECT fc.flash_card_id, front_text, back_text, fc.deck_id " +
                                   "FROM flashcards fc " +
                                   "INNER JOIN Flashcards_Tags ft ON ft.flash_card_id = fc.flash_card_id " +
                                   "INNER JOIN Tags t ON t.tag_id = ft.tag_id " +
                                   "INNER JOIN Decks d ON d.deck_id = fc.deck_id " +
                                   "INNER JOIN Users u ON u.user_id = d.user_id " +
                                   "WHERE t.name = @tagName AND u.user_id = @userId";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@tag", tag);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FlashCard flashCard = new FlashCard
                            {
                                Id = Convert.ToInt32(reader["flash_card_id"]),
                                FrontText = Convert.ToString(reader["front_text"]),
                                BackText = Convert.ToString(reader["back_text"]),
                                DeckId = Convert.ToInt32(reader["deck_id"])
                            };

                            flashCards.Add(flashCard);
                        }
                    }
                }
            }
            return flashCards;
        }
    }
}
