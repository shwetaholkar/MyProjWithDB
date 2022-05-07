using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjWithDB
{
    internal class Sample1
    {
        public void SampleStore1()
        {
            //1.create your connection
            string connectionString = @"Data Source=DESKTOP-ERGIE03\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //2.Command
            string queryString = "select * from production.products";
            SqlCommand command = new SqlCommand(queryString, connection);

            //3.reader
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
            }
            reader.Close();
            connection.Close();
        }
        public void SampleStore2()
        {
            string connectionString = @"Data Source=DESKTOP-ERGIE03\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryString = "select * from production.products";
                SqlCommand command = new SqlCommand(queryString, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader[0].ToString() + " " + reader[1].ToString());
                    }
                }
            }
        }
        public void SampleStore3()
        {
            string connectionString = @"Data Source=DESKTOP-ERGIE03\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "update production.products set list_price=list_price * 10";
                SqlCommand command = new SqlCommand(query, connection);
                int rowsffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsffected);
            }

        }
        public void SampleStore5()
        {
            string connectionString = @"Data Source=DESKTOP-ERGIE03\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("testSP", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@min_price", 100));
                command.Parameters.Add(new SqlParameter("@max_price", 200));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());

                    }
                }
            }
        }
    }
}


