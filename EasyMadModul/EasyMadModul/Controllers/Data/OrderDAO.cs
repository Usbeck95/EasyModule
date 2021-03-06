using EasyMadModul.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;


namespace EasyMadModul.Controllers.Data
{
    internal class OrderDAO  //DataAccessObject
    {
        //connection to database
        string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        // GOing to perform all operations concerning orderdata
        public List<OrderModel> FetchOrder()
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "SELECT * from dbo.Orders";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {

                  
                        OrderModel order = new OrderModel();
                        order.Id = reader.GetInt32(0);
                        order.MemNumb = reader.GetInt32(1);
                        order.Department = reader.GetInt32(2);
                        order.DishName = reader.GetString(3);
                        order.ImgName = reader.GetString(4);
                        order.ImgExt = reader.GetString(5);
                        order.ImgPath = reader.GetString(6);
                        order.OrderCmnt = reader.GetString(7);
                        order.OrderTime = reader.GetDateTime(8);
                        order.State = reader.GetInt32(9);

                        returnList.Add(order);

                    }
                }
            }


                return returnList;
        }
        // efter fetchorder var lavet, skulle der ikke meget ændring af de kommende funktioner, til at gå ind og vælge ud fra hvilket state de var i.

        public OrderModel FetchOneOrder(int Id)
        {


            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "SELECT * from dbo.Orders WHERE Id = @Id";
                // til sqlQuerien der skriver vi at Id skal matche @id. Så derfor skal der addes en parameter, hvor den får at vide, hvor @id stammer fra.
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;
                // fortsættelse til forrige kommentar. = Id. Den parameter skal matche med den parameter, som man gav funktionen FetchOneOrder.

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                // i fetchoneorder, der returnerer jeg en order. Så forskellig fra fetchorder. Derfor bliver jeg nød til i denne funktion at rykke deklarationen af order ud af while loopet. Ellers ligger definationen af order kun inde i while loopets scope.
                OrderModel order = new OrderModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {



                        order.Id = reader.GetInt32(0);
                        order.MemNumb = reader.GetInt32(1);
                        order.Department = reader.GetInt32(2);
                        order.DishName = reader.GetString(3);
                        order.ImgName = reader.GetString(4);
                        order.ImgExt = reader.GetString(5);
                        order.ImgPath = reader.GetString(6);
                        order.OrderCmnt = reader.GetString(7);
                        order.OrderTime = reader.GetDateTime(8);
                        order.State = reader.GetInt32(9);


                    }
                }



                return order;
            }
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "DELETE FROM dbo.Orders WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;


                connection.Open();

                int deletedID = command.ExecuteNonQuery();


                return deletedID;
            }
        }

        public List<OrderModel> FetchOrder0(string departName)
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "";
                if (departName != null)
                {
                    if (departName == "KittyClubOJ")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 0 AND department = 1";

                    }
                    else if (departName == "Toftegaardens RingridderKlub")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 0 AND department = 2";
                    }
                    else if (departName == "True Crime Kaffeklubben")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 0 AND department = 3";
                    }
                    else if (departName == "RhinestoneCowgirlsClub")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 0 AND department = 4";
                    }

                }
                else
                {
                    sqlQuery = "SELECT * from dbo.Orders WHERE state = 0";
                }
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        OrderModel order = new OrderModel();
                        order.Id = reader.GetInt32(0);
                        order.MemNumb = reader.GetInt32(1);
                        order.Department = reader.GetInt32(2);
                        order.DishName = reader.GetString(3);
                        order.ImgName = reader.GetString(4);
                        order.ImgExt = reader.GetString(5);
                        order.ImgPath = reader.GetString(6);
                        order.OrderCmnt = reader.GetString(7);
                        order.OrderTime = reader.GetDateTime(8);
                        order.State = reader.GetInt32(9);

                        returnList.Add(order);

                    }
                }
            }


            return returnList;
        }

        public List<OrderModel> FetchOrder1(string departName)
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "";
                if (departName != null)
                {
                    if (departName == "KittyClubOJ")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 1 AND department = 1";
                        
                    }
                    else if (departName == "Toftegaardens RingridderKlub")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 1 AND department = 2";
                    }
                    else if (departName == "True Crime Kaffeklubben")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 1 AND department = 3";
                    }
                    else if (departName == "RhinestoneCowgirlsClub")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 1 AND department = 4";
                    }

                }
                else
                {
                    sqlQuery = "SELECT * from dbo.Orders WHERE state = 1";
                }
                
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        OrderModel order = new OrderModel();
                        order.Id = reader.GetInt32(0);
                        order.MemNumb = reader.GetInt32(1);
                        order.Department = reader.GetInt32(2);
                        order.DishName = reader.GetString(3);
                        order.ImgName = reader.GetString(4);
                        order.ImgExt = reader.GetString(5);
                        order.ImgPath = reader.GetString(6);
                        order.OrderCmnt = reader.GetString(7);
                        order.OrderTime = reader.GetDateTime(8);
                        order.State = reader.GetInt32(9);

                        returnList.Add(order);

                    }
                }
            }


            return returnList;
        }

        public List<OrderModel> FetchOrder2(string departName)
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "";
                if (departName != null)
                {
                    if (departName == "KittyClubOJ")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 2 AND department = 1";

                    }
                    else if (departName == "Toftegaardens RingridderKlub")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 2 AND department = 2";
                    }
                    else if (departName == "True Crime Kaffeklubben")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 2 AND department = 3";
                    }
                    else if (departName == "RhinestoneCowgirlsClub")
                    {
                        sqlQuery = "SELECT * from dbo.Orders WHERE state = 2 AND department = 4";
                    }

                }
                else
                {
                    sqlQuery = "SELECT * from dbo.Orders WHERE state = 2";
                }


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        OrderModel order = new OrderModel();
                        order.Id = reader.GetInt32(0);
                        order.MemNumb = reader.GetInt32(1);
                        order.Department = reader.GetInt32(2);
                        order.DishName = reader.GetString(3);
                        order.ImgName = reader.GetString(4);
                        order.ImgExt = reader.GetString(5);
                        order.ImgPath = reader.GetString(6);
                        order.OrderCmnt = reader.GetString(7);
                        order.OrderTime = reader.GetDateTime(8);
                        order.State = reader.GetInt32(9);

                        returnList.Add(order);

                    }
                }
            }


            return returnList;
        }

        public int CreateOrder(OrderModel orderModel, string imgName, string imgExt, string imgPath)
        {
           

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "INSERT INTO dbo.Orders Values(@MemNumb, @Department, @DishName, @ImgName, @ImgExt, @ImgPath, @OrderCmnt, @OrderTime, @State) ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@MemNumb", System.Data.SqlDbType.Int, 1000).Value = orderModel.MemNumb;
                command.Parameters.Add("@Department", System.Data.SqlDbType.Int, 1000).Value = orderModel.Department;
                command.Parameters.Add("@DishName", System.Data.SqlDbType.NVarChar, 1000).Value = orderModel.DishName;

                // Så fordi jeg endnu ikke har en fungerende måde at gemme billeder på i min databse, så bliver programmet rimelig sur, når jeg har sagt jeg vil lave en ny ordre ud fra hele min ordremodel. Men jeg kan jo ikke rigtig give den et billede endnu, og af andre grunde kan det måske være klogt nok, at have en løsning til, hvis brugeren ikke udfylder feltet. Derfor måtte jeg tilføje noget mere kode til parameter tilføjelsen til billede. For at det blev ordentlig syntaks, så måtte jeg også dele noget at koden op og definere en ny sqlparameter. 



                /*
                                SqlParameter imageParam = command.Parameters.Add("@DishImg", System.Data.SqlDbType.Image);
                                imageParam.Value = orderModel.DishImg;

                                if (orderModel.DishImg == null)
                                {
                                    imageParam.Value = DBNull.Value;
                                }*/

               /* string imgName = Path.GetFileName(file.FileName);
                string imgExt = Path.GetExtension(imgName);
                if(imgExt == ".jpg" || imgExt == ".png")
                {
                    string imgPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), imgName);
                    file.SaveAs(imgName);*/

                    command.Parameters.Add("@ImgName", System.Data.SqlDbType.VarChar, 1000).Value = imgName;
                    command.Parameters.Add("@ImgExt", System.Data.SqlDbType.VarChar, 1000).Value = imgExt;
                    command.Parameters.Add("@ImgPath", System.Data.SqlDbType.VarChar, 1000).Value = imgPath;
              /*  }*/

                command.Parameters.Add("@OrderCmnt", System.Data.SqlDbType.NVarChar, 1000).Value = orderModel.OrderCmnt;

                command.Parameters.Add("@OrderTime", System.Data.SqlDbType.DateTime2).Value = orderModel.OrderTime;
                
                command.Parameters.Add("@State", System.Data.SqlDbType.Int, 1000).Value = orderModel.State;
               
              

                connection.Open();

                int newID = command.ExecuteNonQuery();


            return newID;
        }
    }

        public int UpdateOrder(OrderModel orderModel)
        {

            // if ordermodel.state = 0 then update to 1
            // if ordermodel.state = 1 then update to 2

            
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "UPDATE dbo.Orders SET State = @State WHERE Id = @Id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = orderModel.Id;

                if (orderModel.State == 0)
                {

                    Console.WriteLine("Ordren havde en state 0");
                    command.Parameters.Add("@State", System.Data.SqlDbType.Int, 1000).Value = 1;

                }
                else if (orderModel.State == 1)
                {

                    Console.WriteLine("Ordren havde en state 1");
                    command.Parameters.Add("@State", System.Data.SqlDbType.Int, 1000).Value = 2;
                }
                else
                {
                    Console.WriteLine("Noget gik galt");
                }
                
                connection.Open();

                int newState = command.ExecuteNonQuery();


                return newState;
            }
        }
    }
}