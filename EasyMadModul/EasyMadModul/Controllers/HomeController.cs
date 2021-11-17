using EasyMadModul.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using EasyMadModul.Handlers;


namespace EasyMadModul.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // GET: Users
         /*   List<UserModel> users = new List<UserModel>();

            UserHandler userList = new UserHandler();

            users = userList.FetchAll();*/

            return View("Index");
        }

        public ActionResult Index1()
        {
            // GET: Users
          

            return View("Index1");
        }

        UserHandler departmentList = new UserHandler();

        public ActionResult Index2()
        {
           /* UserModel MD = new UserModel();
            MD.Departmentlist = new SelectList(departmentList.FetchDepartments(), "Id", "DepartmentId"); // model binding*/
            return View();
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