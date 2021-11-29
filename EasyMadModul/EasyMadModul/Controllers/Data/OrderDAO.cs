using EasyMadModul.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace EasyMadModul.Controllers.Data
{
    internal class OrderDAO
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
                        order.DishName = reader.GetString(2);
                        // her ville jeg gerne læse dishimg, men den er af type byte[] og skal bruge en del parametre jeg ikke helt forstår, hvor skal komme fra.
                        order.OrderCmnt = reader.GetString(4);
                        order.OrderTime = reader.GetDateTime(5);
                        order.State = reader.GetInt32(6);

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
                        order.DishName = reader.GetString(2);
                        // her ville jeg gerne læse dishimg, men den er af type byte[] og skal bruge en del parametre jeg ikke helt forstår, hvor skal komme fra.
                        order.OrderCmnt = reader.GetString(4);
                        order.OrderTime = reader.GetDateTime(5);
                        order.State = reader.GetInt32(6);



                    }
                }



                return order;
            }
        }
        public List<OrderModel> FetchOrder0()
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "SELECT * from dbo.Orders WHERE state = 0";
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
                        order.DishName = reader.GetString(2);
                        // her ville jeg gerne læse dishimg, men den er af type byte[] og skal bruge en del parametre jeg ikke helt forstår, hvor skal komme fra.
                        order.OrderCmnt = reader.GetString(4);
                        order.OrderTime = reader.GetDateTime(5);
                        order.State = reader.GetInt32(6);

                        returnList.Add(order);

                    }
                }
            }


            return returnList;
        }

        public List<OrderModel> FetchOrder1()
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "SELECT * from dbo.Orders WHERE state = 1";
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
                        order.DishName = reader.GetString(2);
                        // her ville jeg gerne læse dishimg, men den er af type byte[] og skal bruge en del parametre jeg ikke helt forstår, hvor skal komme fra.
                        order.OrderCmnt = reader.GetString(4);
                        order.OrderTime = reader.GetDateTime(5);
                        order.State = reader.GetInt32(6);

                        returnList.Add(order);

                    }
                }
            }


            return returnList;
        }

        public List<OrderModel> FetchOrder2()
        {
            List<OrderModel> returnList = new List<OrderModel>();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "SELECT * from dbo.Orders WHERE state = 2";
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
                        order.DishName = reader.GetString(2);
                        // her ville jeg gerne læse dishimg, men den er af type byte[] og skal bruge en del parametre jeg ikke helt forstår, hvor skal komme fra.
                        order.OrderCmnt = reader.GetString(4);
                        order.OrderTime = reader.GetDateTime(5);
                        order.State = reader.GetInt32(6);

                        returnList.Add(order);

                    }
                }
            }


            return returnList;
        }

        public int CreateOrder(OrderModel orderModel)
        {

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string sqlQuery = "INSERT INTO dbo.Orders Values(@MemNumb, @DishName, @DishImg, @OrderCmnt, @OrderTime, @State) ";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@MemNumb", System.Data.SqlDbType.Int, 1000).Value = orderModel.MemNumb;

                command.Parameters.Add("@DishName", System.Data.SqlDbType.NVarChar, 1000).Value = orderModel.DishName;


                SqlParameter imageParam = command.Parameters.Add("@DishImg", System.Data.SqlDbType.Image);
                imageParam.Value = orderModel.DishImg;
                if (orderModel.DishImg == null)
                {
                    imageParam.Value = DBNull.Value;
                }


                command.Parameters.Add("@OrderCmnt", System.Data.SqlDbType.NVarChar, 1000).Value = orderModel.OrderCmnt;

                command.Parameters.Add("@OrderTime", System.Data.SqlDbType.DateTime2).Value = orderModel.OrderTime;
                /*if (orderModel.OrderTime == null)
                {
                    imageParam.Value = DBNull.Value;
                }*/

                command.Parameters.Add("@State", System.Data.SqlDbType.Int, 1000).Value = orderModel.State;
               
              

                connection.Open();

                int newID = command.ExecuteNonQuery();


            return newID;
        }
    }

    }
}