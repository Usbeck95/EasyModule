using EasyMadModul.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

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
                       
                        order.OrderCmnt = reader.GetString(4);
                        order.OrderTime = reader.GetDateTime(5);
                        order.State = reader.GetInt32(6);

                        returnList.Add(order);

                    }
                }
            }


                return returnList;
        }
    }
}