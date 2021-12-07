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

            const string sql = "SELECT flash_card_id, front_text, back_text, user_id FROM FlashCards";

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
                            card.DeckId = Convert.ToInt32(reader["user_id"]);

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
        /// <returns></returns>
        public IEnumerable<FlashCard> GetFlashCardsFromDeck(int deckId)
        {
            List<FlashCard> cards = new List<FlashCard>();

            const string sql = "SELECT flash_card_id, front_text, back_text, user_id FROM FlashCards WHERE deck_id = @deckId";

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
                            card.DeckId = Convert.ToInt32(reader["user_id"]);

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

                const string sql = "INSERT INTO FlashCards (front_text,back_text,user_id) " +
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
        

        /// <summary>
        /// Get all flash cards specific to a particular user.
        /// </summary>
        /// <param name="deckId"></param>
        /// <returns></returns>
        public List<FlashCard> GetAllFlashCardsFromDeck(int deckId)
        {
            List<FlashCard> cards = new List<FlashCard>();

            const string sql = "SELECT flash_card_id, front_text, back_text, user_id FROM FlashCards WHERE user_id=@userId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@deckId", deckId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FlashCard card = new FlashCard();

                            card.Id = Convert.ToInt32(reader["flash_card_id"]);
                            card.FrontText = Convert.ToString(reader["front_text"]);
                            card.BackText = Convert.ToString(reader["back_text"]);
                            card.DeckId = deckId;

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }
    }
}
