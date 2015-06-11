//============================================================================================
//
// Authors: Dan Friyia, Zack (Kanzhe) Liu
// Course:  COSC 4086
// 
// Description:
//  The Purpose of this class is to encaptulate the creation of user accounts for the
//  various roles. This class is accessable only by the root
//
// Methods:
//  public int CreateFaculty   (string user_id, string password)
//  public int CreateReviewer  (string user_id, string password)
//  public int CreateSupervisor(string user_id, string password)
//  public int CreateSuperAdmin(string user_id, string password)
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
    public class RootFunctionAdapter
    {

        private CourseArray courseList;
        private PartTimeProfessorArray personList;
        private ActivityLog log;
        private LoginAccountArray loginList = new LoginAccountArray();
        private PartTimeProfessorDataAdapter profAdapter;
        private CourseDataAdapter courseAdapter;
        private InstructorDataAdapter instructorDataAdapter;
        private TapRecordAdapter tapAdapter;
        private ActivityLogDataAdapter logAdapter;
        private LoginAdapter loginAdapter;

        //========  ERROR INFORMATION  ========\\
        public static int GENERAL_ERROR = -1;
        public static int ADD_SUCCESSFUL = 1;
        public static int DUPLUCATE_USER = 2;
        public static int NULL_USERNAME = 3;
        public static int NULL_PASSWORD = 4;
        private String user = "dfriyia";
        private String password = "3KLCDnWfH";
        public RootFunctionAdapter()
        {
            profAdapter = new PartTimeProfessorDataAdapter(user, password);
            courseAdapter = new CourseDataAdapter(user, password);
            instructorDataAdapter = new InstructorDataAdapter(user, password);
            tapAdapter = new TapRecordAdapter(user, password);
            logAdapter = new ActivityLogDataAdapter(user, password);
            loginAdapter = new LoginAdapter();
            //initialize!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            log = new ActivityLog(user, password);
            courseList = courseAdapter.RetrieveList();
            personList = profAdapter.RetrieveList();
            TAPArray tapList = tapAdapter.RetrieveList();
            InstructorDataArray insList = instructorDataAdapter.RetrieveList();
            loginList = loginAdapter.GetAll();
            log.InsertRecord("Login.");
            for (int i = 0; i < personList.GetNumOfProf(); i++)
            {
                personList.GetAll()[i].SetTAPList(tapList.GetRecordViaProf(personList.GetAll()[i].GetId()));
                personList.GetAll()[i].SetTeachingCourses(insList.GetRecordViaProf(personList.GetAll()[i].GetId()));

                for (int j = 0; j < insList.GetRecordViaProf(personList.GetAll()[i].GetId()).GetNumOfRecord(); j++)
                {
                    personList.GetAll()[i].SetSeniority(personList.GetAll()[i].GetSeniority()
                        + insList.GetRecordViaProf(personList.GetAll()[i].GetId()).GetAll()[j].GetSeniority());
                }

            }


            for (int i = 0; i < courseList.GetNumOfCourse(); i++)
            {
                courseList.GetAll()[i].SetInstructorList(insList.GetRecordViaCourse(courseList.GetAll()[i].GetFullCourseCode()));
            }

        } // Constructor

        private string MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra;Uid= kaliu ; Pwd= EVIAH23aji;";
        //==================================================================================
        public void CreateLoginAccount(string userType, String user, String userId)
        // This function allows the Root user of the database to create a user account
        // of the FACULTY
        //==================================================================================
        {
            try
            {
                LoginAccount account = new LoginAccount(user, userId, userType);
                loginList.Insert(account);
                loginAdapter.Insert(account);
            }
            catch
            {
            }


            //create a reviewer, reviewer is also a professor
            if (userType.Equals("1"))
            {
                //retrive string from the keyboard

                //
            }
            //create a supervisor
            else if (userType.Equals("2"))
            {
                //return NULL_PASSWORD;
            }
            //create a super administrator
            else if (userType.Equals("3"))
            {
            }
            else
            {
                throw new Exception("User type does not exist.");
            }

        }

        public PartTimeProfessorArray GetAllProfs() 
        {
            return personList;
        }

        public CourseArray GetAllCourses()
        {
            return courseList;
        }

        public void UpdatePersonalInfo(PartTimeProfessor targetProf, String lastName, String middleInitial, String firstName, String workPhone, String homePhone, String SchoolExtention, String algomauEmail, String PrivateEmail, String country, String province, String city, String street, String postcode)
        {
            PartTimeProfessor backup = targetProf.Clone();

            try
            {
                if (!String.IsNullOrEmpty(lastName))
                    targetProf.SetLastName(lastName);
                if (!String.IsNullOrEmpty(middleInitial))
                    targetProf.SetMiddleInitial(middleInitial);
                if (!String.IsNullOrEmpty(firstName))
                    targetProf.SetFirstName(firstName);
                if (!String.IsNullOrEmpty(workPhone))
                    targetProf.SetWorkPhone(workPhone);
                if (!String.IsNullOrEmpty(homePhone))
                    targetProf.SetHomePhone(homePhone);
                if (!String.IsNullOrEmpty(SchoolExtention))
                    targetProf.SetSchoolExtention(SchoolExtention);
                if (!String.IsNullOrEmpty(algomauEmail))
                    targetProf.SetAlgomauEmail(algomauEmail);
                if (!String.IsNullOrEmpty(PrivateEmail))
                    targetProf.SetPrivateEmail(PrivateEmail);
                if (!String.IsNullOrEmpty(country))
                    targetProf.SetCountry(country);
                if (!String.IsNullOrEmpty(province))
                    targetProf.SetProvince(province);
                if (!String.IsNullOrEmpty(city))
                    targetProf.SetCity(city);
                if (!String.IsNullOrEmpty(street))
                    targetProf.SetStreet(street);
                if (!String.IsNullOrEmpty(postcode))
                    targetProf.SetPostcode(postcode);

                profAdapter.Update(targetProf);
            }
            catch (Exception ex)
            {
                targetProf = backup;
                throw ex;
            }
        }
        public void UpdateCourseInfo(Course course, String session, String name, string term, String tapOffer, String cancel, String credit, String evaluate, String numberOfinstructor, String description, String year, String location)
        {
            Course backup = course.Clone();
            try
            {
                if (!String.IsNullOrEmpty(session))
                    course.SetSessionId(session);
                if (!String.IsNullOrEmpty(name))
                    course.SetCourseName(name);
                if (!String.IsNullOrEmpty(term))
                    course.SetTerm(term);
                if (!String.IsNullOrEmpty(tapOffer))
                    course.SetTapOffer(int.Parse(tapOffer));
                if (!String.IsNullOrEmpty(cancel))
                    course.SetCourseCancelled(int.Parse(cancel));
                if (!String.IsNullOrEmpty(credit))
                    course.SetCredit(int.Parse(credit));
                if (!String.IsNullOrEmpty(evaluate))
                    course.SetEvaluationPerformed(int.Parse(evaluate));
                if (!String.IsNullOrEmpty(numberOfinstructor))
                    course.SetTapOffer(int.Parse(numberOfinstructor));
                if (!String.IsNullOrEmpty(description))
                    course.SetCourseDescription(description);
                if (!String.IsNullOrEmpty(year))
                    course.SetYear(year);
                if (!String.IsNullOrEmpty(location))
                    course.SetLocation(location);
                courseAdapter.Update(course);

            }
            catch
            {
                course = backup;
                throw;
            }

        }

        ////==================================================================================
        //public int CreateReviewer(string user_id, string password)
        //// This function allows the Root user of the database to create a user account
        //// of the REVIEWER
        ////==================================================================================
        //{
        //    if (user_id == null || user_id.Equals(""))
        //    {
        //        return NULL_USERNAME;
        //    }
        //    if (password == (null) || password.Equals(""))
        //    {
        //        return NULL_PASSWORD;
        //    }
        //    MySqlConnection connection = new MySqlConnection(MyConnectionString);
        //    MySqlCommand cmd;
        //    connection.Open();
        //    try
        //    {
        //        cmd = connection.CreateCommand();
        //        cmd.CommandText = "CREATE USER '" + user_id + "'@'localhost' IDENTIFIED BY '" + password + "'; ";
        //        cmd.CommandText += "grant select on course_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant select on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant select on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (MySqlException e)
        //    {
        //        switch (e.Number)
        //        {
        //            case 1396:
        //                return DUPLUCATE_USER;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return GENERAL_ERROR;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return ADD_SUCCESSFUL;
        //}
        ////==================================================================================
        //public int CreateSupervisor(string user_id, string password)
        //// This function allows the Root user of the database to create a user account
        //// of the SUPERVISOR
        ////==================================================================================
        //{
        //    if (user_id == null || user_id.Equals(""))
        //    {
        //        return NULL_USERNAME;
        //    }
        //    if (password == (null) || password.Equals(""))
        //    {
        //        return NULL_PASSWORD;
        //    }
        //    MySqlConnection connection = new MySqlConnection(MyConnectionString);
        //    MySqlCommand cmd;
        //    connection.Open();
        //    try
        //    {
        //        cmd = connection.CreateCommand();
        //        cmd.CommandText = "CREATE USER '" + user_id + "'@'localhost' IDENTIFIED BY '" + password + "'; ";
        //        cmd.CommandText += "grant select on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant select on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant insert on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant insert on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant update on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant update on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (MySqlException e)
        //    {
        //        switch (e.Number)
        //        {
        //            case 1396:
        //                return DUPLUCATE_USER;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return GENERAL_ERROR;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return ADD_SUCCESSFUL;
        //}

        ////==================================================================================
        //public int CreateSuperAdmin(string user_id, string password)
        //// This function allows the Root user of the database to create a user account
        //// of the REVIEWER
        ////==================================================================================
        //{
        //    if (user_id == null || user_id.Equals(""))
        //    {
        //        return NULL_USERNAME;
        //    }
        //    if (password == (null) || password.Equals(""))
        //    {
        //        return NULL_PASSWORD;
        //    }
        //    MySqlConnection connection = new MySqlConnection(MyConnectionString);
        //    MySqlCommand cmd;
        //    connection.Open();
        //    try
        //    {
        //        cmd = connection.CreateCommand();
        //        cmd.CommandText = "CREATE USER '" + user_id + "'@'localhost' IDENTIFIED BY '" + password + "'; ";
        //        cmd.CommandText += "grant select on course_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant insert on course_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant update on course_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant delete on course_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant select on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant insert on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant update on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant delete on aggregate_person_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant select on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant insert on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant update on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.CommandText += "grant delete on part_time_information_data to '" + user_id + "'@'localhost'; ";
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (MySqlException e)
        //    {
        //        switch (e.Number)
        //        {
        //            case 1396:
        //                return DUPLUCATE_USER;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return GENERAL_ERROR;
        //    }
        //    finally
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }
        //    }
        //    return ADD_SUCCESSFUL;
        //}
    }
}