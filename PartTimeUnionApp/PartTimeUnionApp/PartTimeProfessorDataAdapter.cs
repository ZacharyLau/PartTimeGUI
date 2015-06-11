//============================================================================================
//
// Authors: Dan Friyia, Zack (Kanzhe) Liu
// Course:  COSC 4086
// Table:   COURSE_DATA
// 
// Description:
//		The Purpose of this class is to encaptulate the viewing, insertion, deletion
//		and Updating of the course_data table.
//
// Methods:
//		Insert(** INSERTION DATA **): bool
//		Delete(): bool
//		Delete(id: string): bool
//		Update(** INSERTION DATA NO UD): bool
//		Update(** INSERTION DATA WITH ID**): bool
//		retrieveData(): string[]
//		RetrieveAll():  string[,]
//
//============================================================================================

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
	public class PartTimeProfessorDataAdapter
	{
		private string MyConnectionString;
		private string username;
		private string password;


        public PartTimeProfessorDataAdapter(string user = "dfriyia", string pass = "3KLCDnWfH")
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

        public PartTimeProfessorArray RetrieveList()
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            //CourseArray courseList = new CourseArray();
            connection.Open();
            string[] dataItems;
            PartTimeProfessorArray profList = new PartTimeProfessorArray();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM part_time_professor_data";
                MySqlDataReader reader = cmd.ExecuteReader();

                dataItems = new string[14];           
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
                    dataItems[8] = reader.IsDBNull(8) ? "null" : reader.GetString(8);
                    dataItems[9] = reader.IsDBNull(9) ? "null" : reader.GetString(9);
                    dataItems[10] = reader.IsDBNull(10) ? "null" : reader.GetString(10);
                    dataItems[11] = reader.IsDBNull(11) ? "null" : reader.GetString(11);
                    dataItems[12] = reader.IsDBNull(12) ? "null" : reader.GetString(12);
                    dataItems[13] = reader.IsDBNull(12) ? "null" : reader.GetString(13);

                    PartTimeProfessor prof = CreateProf(dataItems);
                    profList.InsertPerson(prof);

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

            return profList;

        }

        private PartTimeProfessor CreateProf(String[] items)
        {
            PartTimeProfessor prof = new PartTimeProfessor();
            //individual_id, last_name, middle_initial, first_name, country, state_province, city, 
            //street, post_code, home_phone, work_phone, school_extension, algomau_email, private_email
            prof.SetId(items[0]);
            prof.SetLastName(items[1]);
            prof.SetMiddleInitial(items[2]);
            prof.SetFirstName(items[3]);
            prof.SetCountry(items[4]);
            prof.SetProvince(items[5]);
            prof.SetCity(items[6]);
            prof.SetStreet(items[7]);
            prof.SetPostcode(items[8]);
            prof.SetHomePhone(items[9]);
            prof.SetWorkPhone(items[10]);
            prof.SetSchoolExtention(items[11]);
            prof.SetAlgomauEmail(items[12]);
            prof.SetPrivateEmail(items[13]);

            
            return prof;
        }

        public PartTimeProfessor RetrieveData(string id)
        {
            string[] dataItems;
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            PartTimeProfessor prof = new PartTimeProfessor();
            try
            {
                dataItems = new string[14];
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM part_time_professor_data WHERE individual_id = @ID";
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
                    dataItems[9] = reader.IsDBNull(8) ? "null" : reader.GetString(9);
                    dataItems[10] = reader.IsDBNull(8) ? "null" : reader.GetString(10);
                    dataItems[11] = reader.IsDBNull(8) ? "null" : reader.GetString(11);
                    dataItems[12] = reader.IsDBNull(8) ? "null" : reader.GetString(12);
                    dataItems[13] = reader.IsDBNull(8) ? "null" : reader.GetString(13);

                    prof = CreateProf(dataItems);

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

            return prof;
        }

        public bool Insert(PartTimeProfessor prof)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO part_time_professor_data (individual_id, last_name, middle_initial, first_name, country, state_province, city, street, post_code, home_phone, work_phone, school_extension, algomau_email, private_email)" +
                                  "VALUES (@individual_id, @last_name,  @middle_initial, @first_name, @country, @state_province, @city, @street, @post_code, @home_phone, @work_phone, @school_extension, @algomau_email, @private_email);";
                cmd.Parameters.AddWithValue("@individual_id", prof.GetId());
                cmd.Parameters.AddWithValue("@last_name", prof.GetLastName());
                cmd.Parameters.AddWithValue("@middle_initial", prof.GetMiddleInitial());
                cmd.Parameters.AddWithValue("@first_name", prof.GetFirstName());
                cmd.Parameters.AddWithValue("@country", prof.GetCountry());
                cmd.Parameters.AddWithValue("@state_province", prof.GetProvince());
                cmd.Parameters.AddWithValue("@city", prof.GetCity());
                cmd.Parameters.AddWithValue("@street", prof.GetStreet());
                cmd.Parameters.AddWithValue("@post_code", prof.GetPostcode());
                cmd.Parameters.AddWithValue("@home_phone", prof.GetHomePhone());
                cmd.Parameters.AddWithValue("@work_phone", prof.GetWorkPhone());
                cmd.Parameters.AddWithValue("@school_extension", prof.GetSchoolExtention());
                cmd.Parameters.AddWithValue("@algomau_email", prof.GetAlgomauEmail());
                cmd.Parameters.AddWithValue("@private_email", prof.GetPrivateEmail());
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

        public bool Update(PartTimeProfessor prof, string element_id, string value)
        // The purpose of this method is to allow the user to update the tuple of their
        // choice. it is an IMPORTANT precondition that the programmer know the
        // id of the tuple they want to change
        //====================================================================================
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE part_time_professor_data SET" + element_id + "= @value WHERE individual_id = @id;";
                cmd.Parameters.AddWithValue("@id", prof.GetId());
                cmd.Parameters.AddWithValue("@value", value);
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


        public bool Update(PartTimeProfessor prof)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE part_time_professor_data SET  last_name = @last_name, middle_initial = @middle_initial, first_name = @first_name, country = @country, state_province = @state_province, city = @city, street = @street, post_code = @post_code, home_phone = @home_phone, work_phone = @work_phone, school_extension = @school_extension, algomau_email = @algomau_email, private_email = @private_email WHERE individual_id = @old_id";
                
                cmd.Parameters.AddWithValue("@last_name", prof.GetLastName());
                cmd.Parameters.AddWithValue("@middle_initial", prof.GetMiddleInitial());
                cmd.Parameters.AddWithValue("@first_name", prof.GetFirstName());
                cmd.Parameters.AddWithValue("@country", prof.GetCountry());
                cmd.Parameters.AddWithValue("@state_province", prof.GetProvince());
                cmd.Parameters.AddWithValue("@city", prof.GetCity());
                cmd.Parameters.AddWithValue("@street", prof.GetStreet());
                cmd.Parameters.AddWithValue("@post_code", prof.GetPostcode());
                cmd.Parameters.AddWithValue("@home_phone", prof.GetHomePhone());
                cmd.Parameters.AddWithValue("@work_phone", prof.GetWorkPhone());
                cmd.Parameters.AddWithValue("@school_extension", prof.GetSchoolExtention());
                cmd.Parameters.AddWithValue("@algomau_email", prof.GetAlgomauEmail());
                cmd.Parameters.AddWithValue("@private_email", prof.GetPrivateEmail());
                cmd.Parameters.AddWithValue("@old_id", prof.GetId());
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
				cmd.CommandText = "SELECT * FROM part_time_professor_data";
				MySqlDataReader reader = cmd.ExecuteReader();

				dataItems = new string[numOfRows(), 14];
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
					dataItems[k, 8] = reader.IsDBNull(8) ? "null" : reader.GetString(8);
					dataItems[k, 9] = reader.IsDBNull(9) ? "null" : reader.GetString(9);
					dataItems[k, 10] = reader.IsDBNull(10) ? "null" : reader.GetString(10);
					dataItems[k, 11] = reader.IsDBNull(11) ? "null" : reader.GetString(11);
					dataItems[k, 12] = reader.IsDBNull(12) ? "null" : reader.GetString(12);
					dataItems[k, 13] = reader.IsDBNull(12) ? "null" : reader.GetString(13);
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
				cmd.CommandText = "SELECT * FROM part_time_professor_data";
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

        //public string[] RetrieveData(string id)
        //{
        //    string[] dataItems;
        //    MySqlConnection connection = new MySqlConnection(MyConnectionString);
        //    connection.Open();
        //    try
        //    {
        //        dataItems = new string[14];
        //        MySqlCommand cmd = connection.CreateCommand();
        //        cmd.CommandText = "SELECT * FROM part_time_professor_data WHERE individual_id = @ID";
        //        cmd.Parameters.AddWithValue("@ID", id);
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            dataItems[0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
        //            dataItems[1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
        //            dataItems[2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
        //            dataItems[3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
        //            dataItems[4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
        //            dataItems[5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
        //            dataItems[6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
        //            dataItems[7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);
        //            dataItems[9] = reader.IsDBNull(8) ? "null" : reader.GetString(9);
        //            dataItems[10] = reader.IsDBNull(8) ? "null" : reader.GetString(10);
        //            dataItems[11] = reader.IsDBNull(8) ? "null" : reader.GetString(11);
        //            dataItems[12] = reader.IsDBNull(8) ? "null" : reader.GetString(12);
        //            dataItems[13] = reader.IsDBNull(8) ? "null" : reader.GetString(13);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }
        //    }

        //    return dataItems;
        //}

		public bool Insert(string individual_id, string last_name, string middle_initial, 
			string first_name, string country, string state_province, string city, 
			string street, string post_code, string home_phone, string work_phone,
			string school_extension, string algomau_email, string private_email)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "INSERT INTO part_time_professor_data (individual_id, last_name, middle_initial, first_name, country, state_province, city, street, post_code, home_phone, work_phone, school_extension, algomau_email, private_email)" +
								  "VALUES (@individual_id, @last_name,  @middle_initial, @first_name, @country, @state_province, @city, @street, @post_code, @home_phone, @work_phone, @school_extension, @algomau_email, @private_email);";
				cmd.Parameters.AddWithValue("@individual_id", individual_id);
				cmd.Parameters.AddWithValue("@last_name", last_name);
				cmd.Parameters.AddWithValue("@middle_initial", middle_initial);
				cmd.Parameters.AddWithValue("@first_name", first_name);
				cmd.Parameters.AddWithValue("@country", country);
				cmd.Parameters.AddWithValue("@state_province", state_province);
				cmd.Parameters.AddWithValue("@city", city);
				cmd.Parameters.AddWithValue("@street", street);
				cmd.Parameters.AddWithValue("@post_code", post_code);
				cmd.Parameters.AddWithValue("@home_phone", home_phone);
				cmd.Parameters.AddWithValue("@work_phone", work_phone);
				cmd.Parameters.AddWithValue("@school_extension", school_extension);
				cmd.Parameters.AddWithValue("@algomau_email", algomau_email);
				cmd.Parameters.AddWithValue("@private_email", private_email);
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
				cmd.CommandText = "DELETE FROM part_time_professor_data WHERE individual_id = @ID;";
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
		public bool Update(string old_id, string individual_id, string last_name, string middle_initial,
			string first_name, string country, string state_province, string city,
			string street, string post_code, string home_phone, string work_phone,
			string school_extension, string algomau_email, string private_email)
		{
			MySqlConnection connection = new MySqlConnection(MyConnectionString);
			MySqlCommand cmd;
			connection.Open();
			try
			{
				cmd = connection.CreateCommand();
				cmd.CommandText = "UPDATE part_time_professor_data SET individual_id = @individual_id, last_name = @last_name, middle_initial = @middle_initial, first_name = @first_name, country = @country, state_province = @state_province, city = @city, street = @street, post_code = @post_code, home_phone = @home_phone, work_phone = @work_phone, school_extension = @school_extension, algomau_email = @algomau_email, private_email = @private_email WHERE individual_id = @old_id";
				cmd.Parameters.AddWithValue("@individual_id", individual_id);
				cmd.Parameters.AddWithValue("@last_name", last_name);
				cmd.Parameters.AddWithValue("@middle_initial", middle_initial);
				cmd.Parameters.AddWithValue("@first_name", first_name);
				cmd.Parameters.AddWithValue("@country", country);
				cmd.Parameters.AddWithValue("@state_province", state_province);
				cmd.Parameters.AddWithValue("@city", city);
				cmd.Parameters.AddWithValue("@street", street);
				cmd.Parameters.AddWithValue("@post_code", post_code);
				cmd.Parameters.AddWithValue("@home_phone", home_phone);
				cmd.Parameters.AddWithValue("@work_phone", work_phone);
				cmd.Parameters.AddWithValue("@school_extension", school_extension);
				cmd.Parameters.AddWithValue("@algomau_email", algomau_email);
				cmd.Parameters.AddWithValue("@private_email", private_email);
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
