using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PartTimeUnionApp
{
    public class LoginAdapter
    {
        private String MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra;Uid= dfriyia ; Pwd= 3KLCDnWfH;";
        private String userType;
        Encryption en;

        public LoginAdapter()
        {
            en = new Encryption();
        }

        public void Login(String LoginName, String password)
        {
           
            bool loop = true;
            while (loop)
            {
                try
                {

                    MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra;Uid= dfriyia ; Pwd= 3KLCDnWfH;";
                    MySqlConnection connection = new MySqlConnection(MyConnectionString);
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    //cmd.CommandText = "SELECT password FROM login_data WHERE username = " + LoginName + ";";
                    cmd.CommandText = "SELECT * FROM login_data WHERE username = @login_name ;";
                    cmd.Parameters.AddWithValue("@login_name", LoginName);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();
                    String s = reader.GetString(2);
                    userType = reader.GetString(3);
                    new ErrorLog().WriteLog("Password: " + s + "  Usertype: " + userType);
                    bool fuck = en.Verify(password, s);
                    new ErrorLog().WriteLog(fuck.ToString());
                    if (fuck)
                    {
                       //four types of users
                       //userType = reader.GetString(3);
                        new ErrorLog().WriteLog(userType);
                        if (userType.Equals("1"))
                        {
                            ReviewerRegistrar reviewer = new ReviewerRegistrar(reader.GetString(1));
                            //call its GUI also
                        }
                        else if (userType.Equals("2"))
                        {
                            SupervisorRegistrar supervisor = new SupervisorRegistrar(reader.GetString(1));
                            //call its GUI
                        }
                        else if (userType.Equals("3"))
                        {

                        }
                        else if (userType.Equals("4"))
                        {
                            ErrorLog log = new ErrorLog();
                            log.WriteLog("Root reached.");
                            new RootHome().Show();

                        }
                        else
                        {
                            throw new Exception();
                        }

                        loop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                   // throw;
                    new ErrorLog().WriteLog(ex.ToString());
                    throw; 
                    //Console.WriteLine("Wrong username or password.");
                }

                finally
                {

                }
            }
        }

        public LoginAccountArray GetAll()
        {
            LoginAccountArray list = new LoginAccountArray();
            String[] dataItems = new String[3];
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT username, user_id, user_type FROM login_data;";
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    LoginAccount account = new LoginAccount();
                    account.SetUserName(reader.IsDBNull(0) ? "null" : reader.GetString(0));
                    account.SetUserId(reader.IsDBNull(1) ? "null" : reader.GetString(1));
                    account.SetUserType(reader.IsDBNull(2) ? "null" : reader.GetString(2));

                    list.Insert(account);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return list;

        }

        public void UpdatePassword(String userId, String password)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "UPDATE login_data SET password = @password WHERE user_id = @id";
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Parameters.AddWithValue("@password", en.Encrypt(password));
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }


        }

        public void UpdateType(String userId, String type)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "UPDATE login_data SET use_type = @type WHERE user_id = @id";
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        public void Insert(LoginAccount account)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "INSERT INTO login_data(username, user_id, password, user_type) VALUES (@name, @id, @password, @type);";
                cmd.Parameters.AddWithValue("@name", account.GetUserName());
                cmd.Parameters.AddWithValue("@id", account.GetUserId());
                cmd.Parameters.AddWithValue("@password", en.Encrypt(account.GetUserId()));
                cmd.Parameters.AddWithValue("@type", account.GetUserType());
                cmd.ExecuteNonQuery();

            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        public void Delete(String id)
        {
            MySqlConnection connection = new MySqlConnection(MyConnectionString);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            try
            {
                cmd.CommandText = "DELETE FROM Login_data WHERE user_id = @ID;";
                cmd.Parameters.AddWithValue("@id", id);
            }
            catch
            {
                throw;
            }
            finally
            {
                connection.Close();
            }


        }


    }
}