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

        public OrderModel(int id, int memNumb, string dishName, string imgName, string imgExt, string imgPath, string orderCmnt, DateTime orderTime, int state)
        {
            Id = id;
            MemNumb = memNumb;
            DishName = dishName;
            ImgName = imgName;
            ImgExt = imgExt;
            ImgPath = imgPath;
            OrderCmnt = orderCmnt;
            OrderTime = orderTime;
            State = state;
        }

        public int Id { get; set; }
        [DisplayName ("Medlemsnummer")]
        public int MemNumb { get; set; }

        public string DishName { get; set; }

        public string ImgName { get; set; }
        public string ImgExt { get; set; }
        public string ImgPath { get; set; }

        public  string OrderCmnt { get; set; }

        public DateTime OrderTime { get; set; }

        public int State { get; set; }
    }
}