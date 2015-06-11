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
	public class InstructorDataAdapter
	{
		private string MyConnectionString;
		private string username;
		private string password;
		private string identification = null;

		public InstructorDataAdapter(string user, string pass)
		{
			username = user;
			password = pass;
            MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra;Uid=" + user + ";Pwd=" + pass + ";";
		}

		//#########################################################################################################
		// 
		//											ZACK'S ADDITIONS
		//
		//#########################################################################################################

        public InstructorDataArray RetrieveList()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            InstructorDataArray instructorList = new InstructorDataArray();
            connection.Open();
            string[] dataItems;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM instructor_data";
                MySqlDataReader reader = cmd.ExecuteReader();

                dataItems = new string[4];
                //int k = 0;
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                   // k++;
                    instructorList.InsertRecord(CreateRecord(dataItems));

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

            return instructorList;

        }

        private InstructorData CreateRecord(String[] item)
        {
            InstructorData data = new InstructorData();
            data.SetProf(item[0]);
            data.SetCourse(item[1]);
            data.SetSeniority(int.Parse(item[3]));
            data.SetDate(DateTime.Parse(item[2]));

            return data;
        }


        public bool Insert(InstructorData data)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO instructor_data(instructor_id, course_code, seniority, course_date) VALUES (@instructor_id, @course_code, @seniority, @course_date);";
                cmd.Parameters.AddWithValue("@instructor_id", data.GetProf());
                cmd.Parameters.AddWithValue("@course_code", data.GetCourse());
                cmd.Parameters.AddWithValue("@seniority", data.GetSeniority());
                cmd.Parameters.AddWithValue("@course_date", data.GetDate());
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
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

        public InstructorDataArray RetrieveViaProf(String id)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            InstructorDataArray instructorList = new InstructorDataArray();
            connection.Open();
            string[] dataItems;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM instructor_data WHERE instructor_id = @id";
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                dataItems = new string[4];
                //int k = 0;
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    // k++;
                    instructorList.InsertRecord(CreateRecord(dataItems));

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

            return instructorList;

        }

        public InstructorDataArray RetrieveViaCourse(String code)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            InstructorDataArray instructorList = new InstructorDataArray();
            connection.Open();
            string[] dataItems;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM instructor_data WHERE course_code = @code";
                cmd.Parameters.AddWithValue("@code", code);
                MySqlDataReader reader = cmd.ExecuteReader();

                dataItems = new string[4];
                //int k = 0;
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    // k++;
                    instructorList.InsertRecord(CreateRecord(dataItems));

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

            return instructorList;

        }

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
				cmd.CommandText = "SELECT * FROM instructor_data";
				MySqlDataReader reader = cmd.ExecuteReader();

				dataItems = new string[numOfRows(), 4];
				int k = 0;
				while (reader.Read())
				{
					dataItems[k, 0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
					dataItems[k, 1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
					dataItems[k, 2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
					dataItems[k, 3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
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
				cmd.CommandText = "SELECT * FROM instructor_data";
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
				cmd.CommandText = "SELECT * FROM instructor_data WHERE instructor_id = @ID";
				cmd.Parameters.AddWithValue("@ID", id);	
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
					dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
					dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
					dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
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

		public bool Insert(string instructor_id, string course_code, string stipend, DateTime course_date)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "INSERT INTO instructor_data(instructor_id, course_code, seniority, course_date) VALUES (@instructor_id, @course_code, @seniority, @course_date);";
				cmd.Parameters.AddWithValue("@instructor_id", instructor_id);
				cmd.Parameters.AddWithValue("@course_code", course_code);
				cmd.Parameters.AddWithValue("@seniority", stipend);
				cmd.Parameters.AddWithValue("@course_date", course_date);
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

		public bool Delete(string id)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();

			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "DELETE FROM instructor_data WHERE course_code = @ID;";
				cmd.Parameters.AddWithValue("@ID", id);
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

		public bool Update(string course, string instructor_id, string course_code, string stipend, DateTime course_date)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "UPDATE instructor_data SET seniority = @seniority, course_date = @course_date WHERE instructor_id = @old_id";
				cmd.Parameters.AddWithValue("@instructor_id", instructor_id);
				cmd.Parameters.AddWithValue("@course_code", course_code);
				cmd.Parameters.AddWithValue("@seniority", stipend);
				cmd.Parameters.AddWithValue("@course_date", course_date);
				cmd.Parameters.AddWithValue("@old_id", course);
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
