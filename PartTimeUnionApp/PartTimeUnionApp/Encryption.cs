using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
//reference https://msdn.microsoft.com/en-us/library/s02tk69a.aspx

namespace PartTimeUnionApp
{
    public class Encryption
    {
        private String MyConnectionString = @"Server=sapphire.algomau.ca; Port=3306; Database=extra;Uid= kaliu ; Pwd= EVIAH23aji;";
        private String hash;

        public Encryption()
        {
            //MySqlConnection connection = new MySqlConnection(MyConnectionString);
            //connection.Open();
            //MySqlCommand cmd = connection.CreateCommand();
            //cmd.CommandText = "SELECT * FROM Encryption";
            //MySqlDataReader reader = cmd.ExecuteReader();
            //hash = reader.GetString(0);
            hash = "x2";

        }

        public String Encrypt(String raw)
        {
            MD5 md5Hash = MD5.Create();
           
            byte[] bytePassword = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(raw));
            StringBuilder encrypted = new StringBuilder();
            for (int i = 0; i < bytePassword.Length; i++)
            {
                encrypted.Append(bytePassword[i].ToString(hash));
            }

            return encrypted.ToString();

        }

        public bool Verify(String input, String source)
        {
            new ErrorLog().WriteLog("Call verify function.");
            String encrypted = Encrypt(input);
            new ErrorLog().WriteLog("Input: " + encrypted +" \n " + "  Source: " + source);
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            new ErrorLog().WriteLog("Compare result: "+comparer.Compare(input, source).ToString());
            if (0 == comparer.Compare(encrypted, source))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
