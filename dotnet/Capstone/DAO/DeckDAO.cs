﻿using Capstone.DAO;
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

        /// <summary>
        /// Adding to the database a brand new deck for user account.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deckName"></param>
        /// <returns></returns>
        public Deck CreateDeck(int userId, string deckName)
        {
            Deck newDeck = new Deck();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                const string sql = "INSERT INTO Decks (user_id,deck_name) " +
                    "VALUES(@userId,@deckName); " +
                    "SELECT @@IDENTITY";

                using (SqlCommand command = new SqlCommand(sql,conn))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@deckName", deckName);

                    int newId = Convert.ToInt32(command.ExecuteScalar());
                    newDeck.Id = newId;
                    newDeck.Name = deckName;
                    newDeck.UserId = userId;
                }
            }

            return newDeck;
        }
    }
}
