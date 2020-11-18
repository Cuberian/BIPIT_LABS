using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BIPIT05
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in both code and config file together.
    public class Service : IService
    {
        public static string connectStr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=bipitpj;Integrated Security=True";
        public SqlConnection sqlConnect = new SqlConnection(connectStr);

        public Dictionary<int, string> GetClients()
        {
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("SELECT client_id, client_fullname FROM [Clients]", sqlConnect);
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            while (reader.Read())
            {
                dict.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }
            sqlConnect.Close();
            return dict;
        }

        public Shippings[] GetData()
        {
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("SELECT shipping_id, client_fullname, service_title, service_cost, FORMAT (shipping_date, 'dd.MM.yyyy') as shipping_date FROM [View_3]", sqlConnect);
            SqlDataReader reader = command.ExecuteReader();
            List<Shippings> data = new List<Shippings>();
            while (reader.Read())
            {
                Shippings shipping = new Shippings
                {
                    ShippingID = reader["shipping_id"].ToString(),
                    ClientFullname = reader["client_fullname"].ToString(),
                    ServiceTitle = reader["service_title"].ToString(),
                    ServiceCost = reader["service_cost"].ToString(),
                    ShippingDate= reader["shipping_date"].ToString(),
                };
                data.Add(shipping);
            }
            reader.Close();
            sqlConnect.Close();
            return data.ToArray();
        }

        public void NewRec(int client_id, int service_id, DateTime shipping_date)
        {
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [Shippings] (client_id, service_id, shipping_date) VALUES (@client_id, @service_id, @shipping_date)", sqlConnect);
            command.Parameters.AddWithValue("client_id", client_id);
            command.Parameters.AddWithValue("service_id", service_id);
            command.Parameters.AddWithValue("shipping_date", shipping_date);
            command.ExecuteNonQuery();
            sqlConnect.Close();
        }

        public Dictionary<int, string> GetServices()
        {
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("SELECT service_id, service_title FROM [Services]", sqlConnect);
            SqlDataReader reader = command.ExecuteReader();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            while (reader.Read())
            {
                dict.Add(Convert.ToInt32(reader[0]), reader[1].ToString());
            }
            sqlConnect.Close();
            return dict;
        }

        public bool isHostAlive()
        {
            return true;
        }
    }
}
