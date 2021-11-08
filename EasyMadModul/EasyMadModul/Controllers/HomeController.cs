using EasyMadModul.Models;
using System.Collections.Generic;
using System.Web.Mvc;



namespace EasyMadModul.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var model = new List<UserModel>();

            model.Add(new UserModel(0, "Maple", "Kittyclub", 24601));
            model.Add(new UserModel(1, "Emily", "Kittyclub", 24602));
            model.Add(new UserModel(2, "Tequila", "Horsieclub", 24603));
            model.Add(new UserModel(3, "Nube", "Horsieclub", 24604));
            model.Add(new UserModel(4, "Möble", "Kittyclub", 24605));
            model.Add(new UserModel(5, "Emmerloo", "Kittyclub", 24606));
            model.Add(new UserModel(6, "Pöbli", "Kittyclub", 24607));

            return View(model);
        }

        public ActionResult Afventer()
        {
            var model = new List<FoodCardModel>();

            model.Add(new FoodCardModel(0, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(2, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(1, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(3, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(4, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(5, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));


            return View(model);
        }

        public ActionResult Udleveret()
        {
           

            return View();
        }
    }
}