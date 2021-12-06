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
                            card.CreatedBy = Convert.ToInt32(reader["user_id"]);

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }

        // Need a method to create a new FlashCard
        public FlashCard AddNewCard(int userId, FlashCard cardToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "INSERT INTO FlashCards (front_text,back_text,user_id) " +
                    "VALUES(@FrontText,@BackText,@CreatedBy); " +
                    "SELECT @@IDENTITY;";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@FrontText", cardToAdd.FrontText);
                    command.Parameters.AddWithValue("@BackText", cardToAdd.BackText);
                    command.Parameters.AddWithValue("@CreatedBy", userId);

                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    cardToAdd.Id = newId;
                }
            }

            return cardToAdd;
        }

        // Need a method to pull cards specific to the user
        public List<FlashCard> GetAllFlashCardsForUser(int userId)
        {
            List<FlashCard> cards = new List<FlashCard>();

            const string sql = "SELECT flash_card_id, front_text, back_text, user_id FROM FlashCards WHERE user_id=@userId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FlashCard card = new FlashCard();

                            card.Id = Convert.ToInt32(reader["flash_card_id"]);
                            card.FrontText = Convert.ToString(reader["front_text"]);
                            card.BackText = Convert.ToString(reader["back_text"]);
                            card.CreatedBy = userId;

                            cards.Add(card);
                        }
                    }
                }
            }

            return cards;
        }

    }
}
