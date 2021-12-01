using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;

namespace EasyMadModul.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
        }

        public OrderModel(int id, int memNumb, string dishName, Image dishImg, string orderCmnt, DateTime orderTime, int state)
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
        [DisplayName ("Medlemsnummer")]
        public int MemNumb { get; set; }

        public string DishName { get; set; }

        public Image DishImg { get; set; }

        public  string OrderCmnt { get; set; }

        public DateTime OrderTime { get; set; }

        public int State { get; set; }
    }
}