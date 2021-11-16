using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMadModul.Models
{
    public class OrderModel
    {
        public OrderModel(int id, int memNumb, string dishName, byte[] dishImg, string orderCmnt, DateTime orderTime, int state)
        {
            Id = id;
            MemNumb = memNumb;
            DishName = dishName;
            DishImg = dishImg;
            OrderCmnt = orderCmnt;
            OrderTime = orderTime;
            State = state;
        }

        public int Id { get; set; }

        public int MemNumb { get; set; }

        public string DishName { get; set; }

        public Byte[] DishImg { get; set; }

        public  string OrderCmnt { get; set; }

        public DateTime OrderTime { get; set; }

        public int State { get; set; }
    }
}