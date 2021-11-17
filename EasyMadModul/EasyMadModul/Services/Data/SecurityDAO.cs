using EasyMadModul.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EasyMadModul.Services.Data
{
    public class SecurityDAO
    {
        //connection to database
        string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        internal bool FindByDepartment(DepartmentModel department)
        {
            bool success = false;

            // prepared statement som forhindrer sql injection attacks
            string queryString = "SELECT * from dbo.Departments WHERE department = @Department AND password = @Password";

            // benytter sig af en using block, der åbner og lukker forbindelsen til databasen.
            // så alt bliver lukket når query er færdig

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // sqlcommand er en allerede defineret command, som man kan benytte sig af. Den bruger to parametere.
                SqlCommand command = new SqlCommand(queryString, connection);

                // fortæller sammenhængen mellem @Department og værdien for modellen departmen.department
                command.Parameters.Add("@Department", System.Data.SqlDbType.NVarChar).Value = department.Department;
                command.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar, 50).Value = department.Password;

                //åbner databassen og kører command. Der er en mulighed for at det ikke vil lykkes og derfor er det en god ide at lave en try catch, så man har en mulighed hvis ens try så ikke kan udføres. 
                try
                {
                    //kigger efter i databasen med sqldatareader og metoden executereader. readeren kigger efter om der findes nogle rows der kan matche vores command.
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    // vi lukker readeren når vi er færdig med den.
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