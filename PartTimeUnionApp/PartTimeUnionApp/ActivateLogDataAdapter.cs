using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PartTimeUnionApp
{
    public class ActivityLogDataAdapter
    {
        private static String MyConnectionString;// = "Server=localHost;Database=Record_System_Schema;Uid=root;Pwd=root;";
       // private static MySqlConnection connection = new MySqlConnection(myConnectionString);
        //private MySqlCommand cmd = connection.CreateCommand();

        public ActivityLogDataAdapter(String user, String password)
        {
            MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra;Uid=" + user + ";Pwd=" + password + ";";
        }

        public void InsertRecord(String id, String log)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            connection.Open();
            try
            {
                DateTime date = DateTime.Today;
                cmd.CommandText = "Insert into Activity_log(date, individual_id, action_log) + values(@date, @id, @log);";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@log", log);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();//do something later
            }
            finally 
            {
                connection.Close();
            }

        }

        public ADTArray<String[]> GetRecord(String id) 
        {
            //0:date
            //1:id
            //2:message
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd = connection.CreateCommand();
            ADTArray<String[]> record = new ADTArray<string[]>();
            connection.Open();

            try
            {
                cmd.CommandText = "Select * from Activity_log where individual_id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    String[] tempRecord = new String[3];
                    tempRecord[0] = reader.IsDBNull(0) ? "Null" : reader.GetString(0);
                    tempRecord[1] = reader.IsDBNull(1) ? "Null" : reader.GetString(1);
                    tempRecord[2] = reader.IsDBNull(2) ? "Null" : reader.GetString(2);

                    record.Insert(tempRecord);
                }

            }
            catch (Exception ex)
            {
                //do something later
            }
            finally
            {
                connection.Close();
            }

            return record;
        }
    }
}
