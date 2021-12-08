using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class DeckHelperDAO : IDeckHelperDAO
    {
        private string connectionString;

        public DeckHelperDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Considering a static class/method
        /// <summary>
        /// This method checks that the deck the user has selected will be connected to the current user's account
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deckId"></param>
        /// <returns></returns>
        public bool UserHasAccessToDeck(int userId, int deckId)
        {
            List<Deck> decks = new List<Deck>();

            const string sql = "SELECT deck_id, deck_name FROM decks WHERE deck_id = @deck_id AND user_id = @user_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@deck_id", deckId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Deck deck = new Deck();

                            deck.Id = Convert.ToInt32(reader["deck_id"]);
                            deck.Name = Convert.ToString(reader["deck_name"]);

                            decks.Add(deck);
                        }
                    }
                }
            }

            if (decks.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// To determine whether or not the deck exists in the database in order to know what the proper http status code should be
        /// </summary>
        /// <param name="deckId"></param>
        /// <returns></returns>
        public bool DeckExists(int deckId)
        {
            Deck deck = new Deck();
            const string sql = "SELECT deck_name FROM decks WHERE deck_id = @deck_id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@deck_id", deckId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            deck.Name = Convert.ToString(reader["deck_name"]);
                        }
                    }
                }
            }

            if (deck.Name == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
