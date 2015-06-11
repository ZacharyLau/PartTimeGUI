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
	public class TapRecordAdapter
	{
		private string MyConnectionString;
		private string username;
		private string password;
		private string identification = null;

		public TapRecordAdapter(string user, string pass)
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

        public TAPArray RetrieveList()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            TAPArray list = new TAPArray();
            connection.Open();
            string[] dataItems;
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tap_record";
                MySqlDataReader reader = cmd.ExecuteReader();

                dataItems = new string[8];
                //int k = 0;
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    dataItems[4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
                    dataItems[5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
                    dataItems[6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
                    dataItems[7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);

                    list.UpdateRecord(CreateTAP(dataItems));
                   // k++;
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

        public TAPRecord CreateTAP(String[] item)
        {
            TAPRecord tap = new TAPRecord();

            tap.SetCourseCode(item[0]);
            tap.UpdateProfessor(item[1]);
            tap.UpdateIsActive(int.Parse(item[2]));
            tap.UpdateTAPDate(DateTime.Parse(item[3]));
            tap.SetCancelDate(DateTime.Parse(item[4]));
            tap.SetExpireDate(DateTime.Parse(item[5]));
            tap.SetInitialDate(DateTime.Parse(item[6]));
            tap.SetPrevious(DateTime.Parse(item[7]));

            return tap;
        }

        public bool Delete(string id, String course)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();

            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM tap_record WHERE individual_id = @ID AND course_code = @code;";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@code", course);
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


        public bool Insert(TAPRecord record)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO tap_record(course_code, individual_id, inactive, tap_date, cancel_date, expire_date, start_date, previous_date) " +
                                  "VALUES (@course_code, @individual_id, @inactive, @tap_date, @cancel_date, @expire_date, @start_date, @previous_date);";
                cmd.Parameters.AddWithValue("@course_code", record.GetCourseInfo());
                cmd.Parameters.AddWithValue("@individual_id", record.GetFacultyInfo());
                cmd.Parameters.AddWithValue("@inactive", record.IsActive());
                cmd.Parameters.AddWithValue("@tap_date", record.GetTAPDate());
                cmd.Parameters.AddWithValue("@cancel_date", record.GetCancelDate());
                cmd.Parameters.AddWithValue("@expire_date", record.GetExpireDate());
                cmd.Parameters.AddWithValue("@start_date", record.GetInitialDate());
                cmd.Parameters.AddWithValue("@previous_date", record.GetPrevious());
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

        public TAPArray RetrieveViaProf(string id)
        {
            string[] dataItems;
            TAPArray list = new TAPArray();
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                dataItems = new string[8];
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tap_record WHERE individual_id = @ID";
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    dataItems[4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
                    dataItems[5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
                    dataItems[6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
                    dataItems[7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);

                    list.UpdateRecord(CreateTAP(dataItems));
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

        public TAPArray RetrieveViaCourse(string coursecode)
        {
            string[] dataItems;
            TAPArray list = new TAPArray();
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                dataItems = new string[8];
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM tap_record WHERE course_code = @code";
                cmd.Parameters.AddWithValue("@code", coursecode);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    dataItems[4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
                    dataItems[5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
                    dataItems[6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
                    dataItems[7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);

                    list.UpdateRecord(CreateTAP(dataItems));
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
				cmd.CommandText = "SELECT * FROM tap_record";
				MySqlDataReader reader = cmd.ExecuteReader();

				dataItems = new string[numOfRows(), 8];
				int k = 0;
				while (reader.Read())
				{
					dataItems[k, 0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
					dataItems[k, 1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
					dataItems[k, 2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
					dataItems[k, 3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
					dataItems[k, 4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
					dataItems[k, 5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
					dataItems[k, 6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
					dataItems[k, 7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);
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
				cmd.CommandText = "SELECT * FROM tap_record";
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
				cmd.CommandText = "SELECT * FROM tap_record WHERE individual_id = @ID";
				cmd.Parameters.AddWithValue("@ID", id);
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
					dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
					dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
					dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
					dataItems[4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
					dataItems[5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
					dataItems[6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
					dataItems[7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);
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

		public bool Insert(string course_code, string individual_id, string inactive,
			string tap_date, string cancel_date, string expire_date, string start_date,
			string previous_date)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "INSERT INTO tap_record(course_code, individual_id, inactive, tap_date, cancel_date, expire_date, start_date, previous_date) " +
								  "VALUES (@course_code, @individual_id, @inactive, @tap_date, @cancel_date, @expire_date, @start_date, @previous_date);";
				cmd.Parameters.AddWithValue("@course_code", course_code);
				cmd.Parameters.AddWithValue("@individual_id", individual_id);
				cmd.Parameters.AddWithValue("@inactive", int.Parse(inactive) );
				cmd.Parameters.AddWithValue("@tap_date", tap_date);
				cmd.Parameters.AddWithValue("@cancel_date", cancel_date);
				cmd.Parameters.AddWithValue("@expire_date", expire_date);
				cmd.Parameters.AddWithValue("@start_date", start_date);
				cmd.Parameters.AddWithValue("@previous_date", previous_date);
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
				cmd.CommandText = "DELETE FROM tap_record WHERE individual_id = @ID;";
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

		// VALUES (individual_id = @individual_id, last_name = @last_name, middle_initial = @middle_initial, first_name = @first_name, country = @country, state_province = @state_province, city = @city, street = @street, post_code = @post_code, home_phone = @home_phone, work_phone = @work_phone, school_extension = @school_extension, algomau_email = @algomau_email, private_email = @private_email);";
		public bool Update(string old_id, string course_code, string individual_id, string inactive,
			string tap_date, string cancel_date, string expire_date, string start_date,
			string previous_date)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "UPDATE tap_record SET course_code = @course_code, individual_id = @individual_id, inactive = @inactive, tap_date = @tap_date, cancel_date = @cancel_date, expire_date = @expire_date, start_date = @start_date, previous_date = @previous_date WHERE individual_id = @old_id";
				cmd.Parameters.AddWithValue("@course_code", course_code);
				cmd.Parameters.AddWithValue("@individual_id", individual_id);
				cmd.Parameters.AddWithValue("@inactive", int.Parse(inactive));
				cmd.Parameters.AddWithValue("@tap_date", tap_date);
				cmd.Parameters.AddWithValue("@cancel_date", cancel_date);
				cmd.Parameters.AddWithValue("@expire_date", expire_date);
				cmd.Parameters.AddWithValue("@start_date", start_date);
				cmd.Parameters.AddWithValue("@previous_date", previous_date);
				cmd.Parameters.AddWithValue("@old_id", old_id);
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
