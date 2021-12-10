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
                            deck.UserId = userId;

                            decks.Add(deck);
                        }
                    }
                }
            }
            return decks;
        }

        /// <summary>
        /// Adding to the database a brand new deck for user account.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deck"></param>
        /// <returns></returns>
        public Deck CreateDeck(int userId, Deck deck)
        {
            Deck newDeck = new Deck();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "INSERT INTO Decks (user_id,deck_name,deck_description) " +
                    "VALUES(@userId,@deckName,@description); " +
                    "SELECT @@IDENTITY";

                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@deckName", deck.Name);
                    command.Parameters.AddWithValue("@description", deck.Description);

                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    newDeck.Id = newId;
                    newDeck.Name = deck.Name;
                    newDeck.UserId = userId;
                    newDeck.Description = deck.Description;
                }
            }

            return newDeck;
        }

        public Deck UpdateDeck(Deck deckToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "UPDATE Decks " +
                    "SET deck_name = @deck_name, deck_description = @deck_description " +
                    "WHERE deck_id = @deck_id";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@deck_name", deckToUpdate.Name);
                    command.Parameters.AddWithValue("@deck_description", deckToUpdate.Description);
                    command.Parameters.AddWithValue("@deck_id", deckToUpdate.Id);

                    command.ExecuteScalar();
                }
            }
        
            return deckToUpdate;
        }

        public void DeleteDeck(int deckId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "DELETE FROM FlashCards " +
                    "WHERE deck_id=@deck_id; " +
                    "DELETE FROM Decks " +
                    "WHERE deck_id=@deck_id;";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@deck_id", deckId);
                    command.ExecuteScalar();
                }
            }
        }
    }
}
