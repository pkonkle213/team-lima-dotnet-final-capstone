using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class FlashCardDAO : IFlashCardDAO
    {
        private string connectionString;

        public FlashCardDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Getting all flashcards in the database
        /// </summary>
        /// <returns></returns>
        public List<FlashCard> GetAllFlashCards()
        {
            List<FlashCard> cards = new List<FlashCard>();

            const string sql = "SELECT flash_card_id, front_text, back_text, deck_id FROM FlashCards";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FlashCard card = new FlashCard();

                            card.Id = Convert.ToInt32(reader["flash_card_id"]);
                            card.FrontText = Convert.ToString(reader["front_text"]);
                            card.BackText = Convert.ToString(reader["back_text"]);
                            card.DeckId = Convert.ToInt32(reader["deck_id"]);

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }

        /// <summary>
        /// Selects all flashcards where they come from a specified deck using the deck_id passed in.
        /// </summary>
        /// <param name="deckId"></param>
        /// /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<FlashCard> GetFlashCardsFromDeck(int deckId, int userId)
        {
            List<FlashCard> cards = new List<FlashCard>();

            const string sql = "SELECT flash_card_id, front_text, back_text, fc.deck_id FROM FlashCards fc " +
                               "INNER JOIN Decks d ON d.deck_id = fc.deck_id " +
                               "INNER JOIN Users u ON u.user_id = d.user_id " +
                               "WHERE fc.deck_id = @deckId AND u.user_id = @userId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@deckId", deckId);
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FlashCard card = new FlashCard();

                            card.Id = Convert.ToInt32(reader["flash_card_id"]);
                            card.FrontText = Convert.ToString(reader["front_text"]);
                            card.BackText = Convert.ToString(reader["back_text"]);
                            card.DeckId = Convert.ToInt32(reader["deck_id"]);
                 
                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }


        /// <summary>
        /// Add a new flashcard to a specific deck of flashcards. This deck will already be specific to a user.
        /// </summary>
        /// <param name="deckId"></param>
        /// <param name="cardToAdd"></param>
        /// <returns></returns>
        public FlashCard AddNewCard(int deckId, FlashCard cardToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "INSERT INTO FlashCards (front_text,back_text,deck_id) " +
                    "VALUES(@FrontText,@BackText,@deckId); " +
                    "SELECT @@IDENTITY;";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@FrontText", cardToAdd.FrontText);
                    command.Parameters.AddWithValue("@BackText", cardToAdd.BackText);
                    command.Parameters.AddWithValue("@deckId", cardToAdd.DeckId);

                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    cardToAdd.Id = newId;
                }
            }

            return cardToAdd;
        } 

        public FlashCard UpdateCard(FlashCard cardToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE FlashCards " +
                    "SET front_text = @front_text, " +
                    "back_text = @back_text " +
                    "WHERE flash_card_id = @cardId; " +
                    "DELETE FROM Flashcards_Tags " +
                    "WHERE flash_card_id=@cardId; ";

                List<int> tagIds = new List<int>();

                foreach(string tag in cardToUpdate.Tags)
                {
                    const string tagSql = "SELECT tag_id FROM Tags " +
                        "WHERE name = @tagName; " +
                        "SELECT @@IDENTITY;";

                    using (SqlCommand command = new SqlCommand(tagSql, conn))
                    {
                        command.Parameters.AddWithValue("@tagName", tag);
                        tagIds.Add(Convert.ToInt32(command.ExecuteScalar()));
                    }
                }

                foreach(int num in tagIds)
                {
                    sql += "INSERT INTO Flashcards_Tags (flash_card_id,tag_id) " +
                        $"VALUES(@cardid, {num}); ";
                }

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@front_text", cardToUpdate.FrontText);
                    command.Parameters.AddWithValue("@back_text", cardToUpdate.BackText);
                    command.Parameters.AddWithValue("@cardId", cardToUpdate.Id);

                    command.ExecuteScalar();
                }
            }

            return cardToUpdate;
        }
        
        public void DeleteCard(int cardId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "DELETE FROM FlashCards " +
                    "WHERE flash_card_id = @cardId";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@cardId", cardId);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Searches the database for any flashcards associated with both the current user, and the keyword (tag) they use to narrow the card search by.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IEnumerable<FlashCard> SearchCardsUsingTag(string tag, int userId)
        {
            List<FlashCard> flashCards = new List<FlashCard>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql =  "SELECT flash_card_id, front_text, back_text, fc.deck_id FROM FlashCards fc " +
                                    "INNER JOIN (flashcard tag join) " +
                                    "WHERE (tag = @tag)";

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
