using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MysqlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //login
            string connectionString = "server=localhost;user=root;database=membership;password=12341qaz";

            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            try
            {
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.Connection = mySqlConnection;

                //mySqlCommand.CommandText = "select * from users where user_id = @user_id and user_password = @user_password";
                mySqlCommand.CommandText = "select * from users limit 0, 10"; // 가져오는 개수 제한
                mySqlCommand.Prepare();
                //mySqlCommand.Parameters.AddWithValue("@user_id", "htk008");
                //mySqlCommand.Parameters.AddWithValue("@user_password", "1234");

                MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader["name"] + " " + dataReader["email"]);
                }

                MySqlCommand mySqlCommand2 = new MySqlCommand();
                //mySqlCommand2.Connection = mySqlConnection;

                //mySqlCommand2.CommandText = "insert into users (user_id, user_password, name, email) values ( @user_id, @user_password, @name, @email)";
                //mySqlCommand2.Prepare();
                //mySqlCommand2.Parameters.AddWithValue("@user_id", "abc002");
                //mySqlCommand2.Parameters.AddWithValue("@user_password", "333");
                //mySqlCommand2.Parameters.AddWithValue("@name", "노형민");
                //mySqlCommand2.Parameters.AddWithValue("@email", "abc001@abc001.com");
                mySqlCommand2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            //Task task = mySqlConnection.OpenAsync();
            //task.Wait();
            //foreach (DataColumn col in userTable.Columns)
            //{
            //    Console.WriteLine(col.ColumnName);
            //}
        }
    }
}
