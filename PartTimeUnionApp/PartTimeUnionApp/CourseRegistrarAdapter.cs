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
	public class CourseRegistrarAdapter
	{
		private string MyConnectionString;
		private string username;
		private string password;
		

		public CourseRegistrarAdapter(string user, string pass)
		{
			username = user;
			password = pass;
			MyConnectionString = @"Server=localhost; Port=3306; Database=record_system_schema;Uid=" + username + ";Pwd=" + password + ";";
		}

		//#########################################################################################################
		// 
		//											ZACK'S ADDITIONS
		//
		//#########################################################################################################
        public CourseRegisterRecordArray RetrieveList()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            CourseRegisterRecordArray list = new CourseRegisterRecordArray();
            connection.Open();
            string[] dataItems;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM course_registrar_data";
                MySqlDataReader reader = cmd.ExecuteReader();

                dataItems = new string[4];
                //int k = 0;
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    list.InsertRecord(CreateRecord(dataItems));
                    
                   //k++;
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

            return list;

        }

        private CourseRegisterRecord CreateRecord(String[] item)
        {
            CourseRegisterRecord record = new CourseRegisterRecord();
            record.SetInstructorId(item[0]);
            record.SetFullCourseCode(item[1]);
            record.SetAccepted(int.Parse(item[2]));
            record.SetOfferDate(DateTime.Parse(item[3]));

            return record;


        }


        public bool Insert(CourseRegisterRecord record)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO course_registrar_data(instructor_id, full_course_code, offer_date, accepted) VALUES (@instructor_id, @full_course_code, @offer_date, @accepted);";
                cmd.Parameters.AddWithValue("@instructor_id", record.GetInstructorId());
                cmd.Parameters.AddWithValue("@full_course_code", record.GetFullCourseCode());
                cmd.Parameters.AddWithValue("@offer_date", record.GetOfferDate());
                cmd.Parameters.AddWithValue("@accepted", record.GetAccepted());
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
				cmd.CommandText = "SELECT * FROM course_registrar_data";
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
				cmd.CommandText = "SELECT * FROM course_registrar_data";
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
				dataItems = new string[4];
				MySqlCommand cmd = connection.CreateCommand();
				cmd.CommandText = "SELECT * FROM course_registrar_data WHERE instructor_id = @ID";
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

		public bool Insert(string instructor_id, string full_course_code, DateTime offer_date, string accepted)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "INSERT INTO course_registrar_data(instructor_id, full_course_code, offer_date, accepted) VALUES (@instructor_id, @full_course_code, @offer_date, @accepted);";
				cmd.Parameters.AddWithValue("@instructor_id", instructor_id);
				cmd.Parameters.AddWithValue("@full_course_code", full_course_code);
				cmd.Parameters.AddWithValue("@offer_date", offer_date);
				cmd.Parameters.AddWithValue("@accepted", int.Parse(accepted));
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
				cmd.CommandText = "DELETE FROM course_registrar_data WHERE full_course_code= @ID;";
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

		public bool Update(string old_id, string instructor_id, string full_course_code, DateTime offer_date, string accepted)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "UPDATE course_registrar_data SET instructor_id = @instructor_id, full_course_code = @full_course_code, offer_date = @offer_date, accepted = @accepted WHERE full_course_code = @old_id";
				cmd.Parameters.AddWithValue("@instructor_id", instructor_id);
				cmd.Parameters.AddWithValue("@full_course_code", full_course_code);
				cmd.Parameters.AddWithValue("@offer_date", offer_date);
				cmd.Parameters.AddWithValue("@accepted", int.Parse(accepted));
				cmd.Parameters.AddWithValue("@old_id", old_id);
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

	}
}
