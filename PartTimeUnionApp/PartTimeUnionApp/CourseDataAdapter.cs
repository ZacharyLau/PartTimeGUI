//============================================================================================
//
// Authors: Dan Friyia, Zack (Kanzhe) Liu
// Course:  COSC 4086
// Table:   COURSE_DATA
// 
// Description:
//  The Purpose of this class is to encaptulate the viewing, insertion, deletion
//  and Updating of the course_data table.
//
// Methods:
//  Insert(** INSERTION DATA **): bool
//  Delete(): bool
//  Delete(id: string): bool
//  Update(** INSERTION DATA NO UD): bool
//  Update(** INSERTION DATA WITH ID**): bool
//  retrieveData(): string[]
//  RetrieveAll():  string[,]
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
    public class CourseDataAdapter
    {
        private string MyConnectionString;
        private string username;
        private string password;
        private string identification = null;

        public CourseDataAdapter(string user = "dfriyia", string pass = "3KLCDnWfH")
        {
            username = user;
            password = pass;
            MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra; Uid=" + user + ";Pwd=" + pass + ";";
        }
        //#########################################################################################################
        // 
        //           ZACK'S ADDITIONS
        //
        //#########################################################################################################
        ////=========================================================
        public CourseArray RetrieveList() //////////////////////////////////////////////Zach changed it: it now returns a course ADT array
        //// Returns all of the values in a table in a 2D array
        ////=========================================================
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            CourseArray courseList = new CourseArray();
            connection.Open();
            //string[,] dataItems; 
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM course_data";
                MySqlDataReader reader = cmd.ExecuteReader();
                //dataItems = new string[numOfRows(), 9];
                String[] dataItems = new string[13];
                //int k = 0;
                while (reader.Read())
                {
                    /*
                    dataItems[k, 0] = reader.IsDBNull(0) ? "null" : reader.GetString(0);
                    dataItems[k, 1] = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                    dataItems[k, 2] = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                    dataItems[k, 3] = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                    dataItems[k, 4] = reader.IsDBNull(4) ? "null" : reader.GetString(4);
                    dataItems[k, 5] = reader.IsDBNull(5) ? "null" : reader.GetString(5);
                    dataItems[k, 6] = reader.IsDBNull(6) ? "null" : reader.GetString(6);
                    dataItems[k, 7] = reader.IsDBNull(7) ? "null" : reader.GetString(7);
                    dataItems[k, 8] = reader.IsDBNull(8) ? "null" : reader.GetString(8);
                    k++;
                    */
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
                    courseList.InsertCourse(CreateCourse(dataItems));
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
            return courseList;
        }

        ////============================================================================
        ////Zach made it, for insert course to course ADT array
        //course_code, seesion_id, course_name, term, tap_offer, course_cacelled, credits, coures_description, evaluation_performed, s_year, localtion, full_course_code, num_of_ins 
        private Course CreateCourse(string[] data)
        {
            Course course = new Course();
            course.SetCourseCode(data[0]);
            course.SetSessionId(data[1]);
            course.SetCourseName(data[2]);
            course.SetTerm(data[3]);
            course.SetTapOffer(int.Parse(data[4]));
            course.SetCourseCancelled(int.Parse(data[5]));
            course.SetCredit(int.Parse(data[6]));
            course.SetCourseDescription(data[7]);
            course.SetEvaluationPerformed(int.Parse(data[8]));
            course.SetYear(data[9]);
            course.SetLocation(data[10]);
            course.SetFullCourseCode(data[11]);
            course.SetNumberOfInstructor(int.Parse(data[12]));
            return course;
        }
        ////=======================================================================================
        ////==============================   OVERLOADED   =========================================
        ////=======================================================================================
        public bool Delete(Course course)
        // The purpose of this method is to encapsulate the details of deletion
        // 
        //=======================================================================================
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM COURSE_DATA WHERE FULL_COURSE_CODE = @ID";
                cmd.Parameters.AddWithValue("@ID", course.GetFullCourseCode());
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
        //Zach's masterpiece, in order to Update course info easily. This method update the string value variables
        /*
         *   cmd.Parameters.AddWithValue("@course_id", course_id);
                cmd.Parameters.AddWithValue("@instructor_id", instructor_id);
                cmd.Parameters.AddWithValue("@course_name", course_name);
                cmd.Parameters.AddWithValue("@term", term);
         */

        public bool Update(Course course, string element_id, string value)
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
                cmd.CommandText = "UPDATE COURSE_DATA SET" + element_id + "= @value WHERE FULL_COURSE_CODE = @course_code;";
                cmd.Parameters.AddWithValue("@course_code", course.GetFullCourseCode());
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
        //Zach's masterpiece vol.2 update the boolean variable
        /* cmd.Parameters.AddWithValue("@tap_offer", int.Parse(tap_offer));
                cmd.Parameters.AddWithValue("@course_cancelled", int.Parse(course_cancelled));
                cmd.Parameters.AddWithValue("@course_description", course_description);
                cmd.Parameters.AddWithValue("@multi_term", int.Parse(multi_term));
                cmd.Parameters.AddWithValue("@evaluation_performed", int.Parse(evaluation_performed));
         * 
         */

        public bool Update(Course course, string element_id, int value)
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
                cmd.CommandText = "UPDATE COURSE_DATA SET" + element_id + "= @value WHERE FULL_COURSE_CODE = @course_code;";
                cmd.Parameters.AddWithValue("@course_code", course.GetCourseCode());
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
        //======================================================================================
        public bool Insert(Course course)
        // The purpose of this function is to encapsulate the 
        // querying requirements of the Insert Function
        //=======================================================================================
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO course_data (course_code, session_id, course_name, term, tap_offer, course_cancelled, credits, course_description, evaluation_performed, s_year, location, full_course_code, number_of_instructors)" +
                                  "VALUES (@course_code,@session_id, @course_name, @term, @tap_offer, @course_cancelled, @credit, @course_description, @evaluation_performed, @s_year, @location, @full_course_code, @num_of_instructor);";
                cmd.Parameters.AddWithValue("@course_code", course.GetCourseCode());
                cmd.Parameters.AddWithValue("@session_id", course.GetSessionId());
                cmd.Parameters.AddWithValue("@course_name", course.GetCourseName());
                cmd.Parameters.AddWithValue("@term", course.GetTerm());
                cmd.Parameters.AddWithValue("@tap_offer", course.GetTapOffer());
                cmd.Parameters.AddWithValue("@course_cancelled", course.GetCourseCancelled());
                cmd.Parameters.AddWithValue("@course_description", course.GetCourseDescription());
                cmd.Parameters.AddWithValue("@credit", course.GetCredit());
                cmd.Parameters.AddWithValue("@evaluation_performed", course.GetEvaluationPerformed());
                cmd.Parameters.AddWithValue("@s_year", course.GetYear());
                cmd.Parameters.AddWithValue("@location", course.GetLocation());
                cmd.Parameters.AddWithValue("@full_course_code", course.GetFullCourseCode());
                cmd.Parameters.AddWithValue("@num_of_instructor", course.GetNumberOfInstructor());
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
        public Course RetrieveACourse(string code)
        {
            string[] dataItems;
            Course course = new Course();
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            try
            {
                dataItems = new string[13];
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM course_data WHERE full_course_code = @code";
                cmd.Parameters.AddWithValue("@code", code);
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
                    dataItems[8] = reader.IsDBNull(8) ? "null" : reader.GetString(8);
                    dataItems[9] = reader.IsDBNull(8) ? "null" : reader.GetString(9);
                    dataItems[10] = reader.IsDBNull(8) ? "null" : reader.GetString(10);
                    dataItems[11] = reader.IsDBNull(8) ? "null" : reader.GetString(11);
                    dataItems[12] = reader.IsDBNull(8) ? "null" : reader.GetString(12);
                    course = CreateCourse(dataItems);
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
            return course;
        }

        public bool Update(Course course)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE course_data SET session_id = @session_id, course_name = @course_name, term = @term, tap_offer = @tap_offer, course_cancelled = @course_cancelled, credits = @credits, course_description = @course_description, evaluation_performed = @evaluation_performed, s_year = @s_year, location = @location, full_course_code = @full_course_code, number_of_instructors = @number_of_instructors WHERE course_code = @old_id";
                //cmd.Parameters.AddWithValue("@course_id", course.GetCourseCode());
                cmd.Parameters.AddWithValue("@session_id", course.GetSessionId());
                cmd.Parameters.AddWithValue("@course_name", course.GetCourseName());
                cmd.Parameters.AddWithValue("@term", course.GetTerm());
                cmd.Parameters.AddWithValue("@tap_offer", course.GetTapOffer());
                cmd.Parameters.AddWithValue("@course_cancelled", course.GetCourseCancelled());
                cmd.Parameters.AddWithValue("@credits", course.GetCredit());
                cmd.Parameters.AddWithValue("@course_description", course.GetCourseDescription());
                cmd.Parameters.AddWithValue("@evaluation_performed", course.GetEvaluationPerformed());
                cmd.Parameters.AddWithValue("@s_year", course.GetYear());
                cmd.Parameters.AddWithValue("@location", course.GetLocation());
                cmd.Parameters.AddWithValue("@full_course_code", course.GetFullCourseCode());
                cmd.Parameters.AddWithValue("@number_of_instructors", course.GetNumberOfInstructor());
                cmd.Parameters.AddWithValue("@old_id", course.GetCourseCode());
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
        //                          \\
        //                          \\
        //         DAN'S WORK, DO NOT CHANGE OR DELETE         \\
        //                          \\
        //                          \\
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
                cmd.CommandText = "SELECT * FROM course_data";
                MySqlDataReader reader = cmd.ExecuteReader();
                dataItems = new string[numOfRows(), 13];
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
                cmd.CommandText = "SELECT * FROM course_data";
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
                dataItems = new string[13];
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM course_data WHERE course_code = @ID";
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
                    dataItems[8] = reader.IsDBNull(8) ? "null" : reader.GetString(8);
                    dataItems[9] = reader.IsDBNull(8) ? "null" : reader.GetString(9);
                    dataItems[10] = reader.IsDBNull(8) ? "null" : reader.GetString(10);
                    dataItems[11] = reader.IsDBNull(8) ? "null" : reader.GetString(11);
                    dataItems[12] = reader.IsDBNull(8) ? "null" : reader.GetString(12);
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
        public bool Insert(string course_id, string session_id, string course_name,
         string term, string tap_offer, string course_cancelled, string credits,
         string course_description, string evaluation_performed,
         string s_year, string location, string full_course_code,
         string number_of_instructors)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO COURSE_DATA (course_code, session_id, course_name, term, tap_offer, course_cancelled, credits, course_description, evaluation_performed, s_year, location, full_course_code, number_of_instructors)" +
                      "VALUES (@course_id, @session_id, @course_name, @term, @tap_offer, @course_cancelled, @credits, @course_description, @evaluation_performed, @s_year, @location, @full_course_code, @number_of_instructors);";
                cmd.Parameters.AddWithValue("@course_id", course_id);
                cmd.Parameters.AddWithValue("@session_id", session_id);
                cmd.Parameters.AddWithValue("@course_name", course_name);
                cmd.Parameters.AddWithValue("@term", term);
                cmd.Parameters.AddWithValue("@tap_offer", int.Parse(tap_offer));
                cmd.Parameters.AddWithValue("@course_cancelled", int.Parse(course_cancelled));
                cmd.Parameters.AddWithValue("@credits", int.Parse(credits));
                cmd.Parameters.AddWithValue("@course_description", course_description);
                cmd.Parameters.AddWithValue("@evaluation_performed", int.Parse(evaluation_performed));
                cmd.Parameters.AddWithValue("@s_year", s_year);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@full_course_code", full_course_code);
                cmd.Parameters.AddWithValue("@number_of_instructors", number_of_instructors);
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
        public bool Delete(string id)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM COURSE_DATA WHERE COURSE_CODE = @ID";
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
        public bool Update(string old_id, string course_id, string session_id, string course_name,
         string term, string tap_offer, string course_cancelled, string credits, string course_description,
         string evaluation_performed, string s_year, string location, string full_course_code,
         string number_of_instructors)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE course_data SET course_code = @course_id, session_id = @session_id, course_name = @course_name, term = @term, tap_offer = @tap_offer, course_cancelled = @course_cancelled, credits = @credits, course_description = @course_description, evaluation_performed = @evaluation_performed, s_year = @s_year, location = @location, full_course_code = @full_course_code, number_of_instructors = @number_of_instructors WHERE course_code = @old_id";
                cmd.Parameters.AddWithValue("@course_id", course_id);
                cmd.Parameters.AddWithValue("@session_id", session_id);
                cmd.Parameters.AddWithValue("@course_name", course_name);
                cmd.Parameters.AddWithValue("@term", term);
                cmd.Parameters.AddWithValue("@tap_offer", int.Parse(tap_offer));
                cmd.Parameters.AddWithValue("@course_cancelled", int.Parse(course_cancelled));
                cmd.Parameters.AddWithValue("@credits", int.Parse(credits));
                cmd.Parameters.AddWithValue("@course_description", course_description);
                cmd.Parameters.AddWithValue("@evaluation_performed", int.Parse(evaluation_performed));
                cmd.Parameters.AddWithValue("@s_year", s_year);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@full_course_code", full_course_code);
                cmd.Parameters.AddWithValue("@number_of_instructors", number_of_instructors);
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