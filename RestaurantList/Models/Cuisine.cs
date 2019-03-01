using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace RestaurantList.Models
{
    public class Cuisine
    {
        private int _id;
        private string _type;
        private int _restaurantId;

        public Cuisine(string type, int id = 0;)
        {
            _type = type;
            _restaurantId = restaurantId;
            _id = id;
        }

        public string GetType()
        {
            return _type;
        }

        public int GetId()
        {
            return _id;
        }

        public static List<Cuisine> GetAll()
        {
            List<Cuisine> allCuisines = new List<Cuisine> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisines;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlCommand;
            while (rdr.Read())
            {
                int cuisineId = rdr.GetInt32(0);
                string type = rdr.GetString(1);
                int restaurantId = rdr.GetInt(2);
                Cuisine newCuisine = new Cuisine(cuisineId, type, restaurantId);
                allCuisines.Add(newCuisine);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCuisines;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM cuisines;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}