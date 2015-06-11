using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PartTimeUnionApp
{
	public class ActivityLogAdapter
	{
		private string MyConnectionString;
		private string username;
		private string password;
		private string identification = null;

		public ActivityLogAdapter(string user, string pass)
		{
			username = user;
			password = pass;
			MyConnectionString = @"Server=localhost; Port=3306; Database=record_system_schema;Uid=" + username + ";Pwd=" + password + ";";
		}

		//#########################################################################################################\\
		//																										   \\
		//											ZACK'S ADDITIONS											   \\
		//																										   \\
		//#########################################################################################################\\

		









		//######################################################################################################\\
		//######################################################################################################\\
		//######################################################################################################\\
		//																										\\
		//																										\\
		//									DAN'S WORK, DO NOT CHANGE OR DELETE									\\
		//																										\\
		//																										\\
		//######################################################################################################\\
		//######################################################################################################\\
		//######################################################################################################\\

		public string[,] RetrieveAll() 
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			//CourseArray courseList = new CourseArray();
			connection.Open();
			string[,] dataItems; 
			try
			{
				MySqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = "SELECT * FROM activity_log";
				MySqlDataReader reader = cmd.ExecuteReader();

				dataItems = new string[numOfRows(), 3];
				int k = 0;
				while (reader.Read())
				{
					dataItems[k, 0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
					dataItems[k, 1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
					dataItems[k, 2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
					k++;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}

			return dataItems;

		}

		public int numOfRows() 
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			connection.Open();
			int count;
			try
			{
				MySqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = "SELECT * FROM activity_log";
				MySqlDataReader reader = cmd.ExecuteReader();
				count = 0;
				while (reader.Read())
				{
					count++;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}
			return count;
		}

		public string[] RetrieveData(string id)
		{
			string[] dataItems;
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			connection.Open();
			try
			{
				dataItems = new string[8];
				MySqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = "SELECT * FROM activity_log WHERE id = @ID";
				cmd.Parameters.AddWithValue("@ID", id);	
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
					dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
					dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}

			return dataItems;
		}

		public bool Insert(DateTime mod_date, string id, string action_log)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "INSERT INTO activity_log (mod_date, id, action_log) VALUES (@mod_date, @id, @action_log);";
				cmd.Parameters.AddWithValue("@mod_date", mod_date);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@action_log", action_log);
				cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				if (connection.State == ConnectionState.Open)
				{
					connection.Close();
				}
			}
			return true;
		}
	}
}
