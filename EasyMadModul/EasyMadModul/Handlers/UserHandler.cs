using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using EasyMadModul.Models;
using System.Data.SqlClient;

namespace EasyMadModul.Handlers
{
    public class UserHandler
    {
       //connection to database
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString; 

        public List<UserModel> FetchAll()
        {
            List<UserModel> returnList = new List<UserModel>();

            // access to database
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "SELECT * from dbo.Users";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                // betyder den bare skal læse noget i databasen så altså ikke ændre noget.
                SqlDataReader reader = command.ExecuteReader();

                // hvis reader finder nogle rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        /* så hver gang at der er en row, som den kan læse, så skal den lave et nyt user object og tilføje det til listen som skal returneres */
                        UserModel user = new UserModel();
                        user.Id = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Department = reader.GetString(2);
                        user.MemNumb = reader.GetInt32(3);

                        returnList.Add(user);
                    }
                }
            }

            return returnList;
        }
       
       internal bool FindByUser(UserModel user)
        {
            // start by assuming it fails and nothing is found
            bool success = false;

            /*write a sql expression string queryString = "SELECT * FROM dbo.Users WHERE name = user.name AND department = user.department AND memNumb = user.memNumb "; men man kan ikke tilgå objektet ved at skrive user.name. i stedet laver man strengen om til at passe med c#*/

            string queryString = "SELECT * FROM dbo.Users WHERE name = @Name AND department = @Department AND memNumb = @MemNumb ";

            // create and open the connection

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // create the command and parameter objects
                SqlCommand command = new SqlCommand(queryString, connection);

                /*fortæller at @Name er det samme som user.Name osv. Da de i databasen har fixes sizes, så skal det med. Derfor int ikke for den ekstra parameter*/
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50).Value = user.Name;
                command.Parameters.Add("@Department", System.Data.SqlDbType.VarChar,-1).Value = user.Department;
                command.Parameters.Add("@MemNumb", System.Data.SqlDbType.Int).Value = user.MemNumb;

                // open the database and run the command.
                try
                {
                    connection.Open();
                    // sørger for koden opover også bliver udført
                    SqlDataReader reader = command.ExecuteReader();
                    // SÅ hvis man har fundet name, department og memnumb, så har man i hvertfald en row. Så hvis vi har rows, så er success lig med true
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
            return success;
        }
    }
}
