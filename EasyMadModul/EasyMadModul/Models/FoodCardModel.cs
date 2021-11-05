using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMadModul.Models
{
    public class FoodCardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FoodDish { get; set; }
        public string FoodImg { get; set; }

        public FoodCardModel(int id, string name, string foodDish, string foodImg)
        {
            Id = id;
            Name = name;
            FoodDish = foodDish;
            FoodImg = foodImg;
        }


    }

}