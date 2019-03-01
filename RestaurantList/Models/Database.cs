using System;
using MySql.Data.MySqlClient;
using RestaurantList;

namespace RestaurantList.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}