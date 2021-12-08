using Capstone.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class DeckDAO : IDeckDAO
    {
        private string connectionString;

        public DeckDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of decks all decks for a user.
        /// Takes in a user's Id which will be identified by the currently logged in user to find associated decks.
        /// </summary>
        /// <returns></returns>
        public List<Deck> GetAllDecks(int userId)
        {
            List<Deck> decks = new List<Deck>();

            const string sql = "SELECT deck_id, deck_name FROM decks WHERE user_id = @user_id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@user_id", userId);
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
            return decks;
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
    }
}
