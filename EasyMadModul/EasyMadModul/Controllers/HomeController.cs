using EasyMadModul.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using EasyMadModul.Handlers;
using EasyMadModul.Controllers;
using System.Web;
using System;
using EasyMadModul.Controllers.Data;
using System.Drawing;
using System.IO;

namespace EasyMadModul.Controllers
{
    public class HomeController : Controller
    {
       /* public ActionResult Index()
        {

            

            Response.Write(Session["Department"]);
            
            *//*   List<UserModel> users = new List<UserModel>();

               UserHandler userList = new UserHandler();

               users = userList.FetchAll();*//*

            return View("Index");
        }*/

     /*   public ActionResult Index1()
        {
            // GET: Users
          

            return View("Index1");
        }

        UserHandler departmentList = new UserHandler();*/

     /*   public ActionResult Index2()
        {
            
            *//* UserModel MD = new UserModel();
             MD.Departmentlist = new SelectList(departmentList.FetchDepartments(), "Id", "DepartmentId"); // model binding*//*
            return View();
        }*/

        /*public ActionResult Afventer()
        {
            var model = new List<FoodCardModel>();

            model.Add(new FoodCardModel(0, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(2, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(1, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(3, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(4, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));
            model.Add(new FoodCardModel(5, "Ejnar Petersen", "Rødkålsgryde", "https://www.rogilds.dk/images/recpics/r0761.jpg"));


            return View(model);
        }*/

       /* public ActionResult Udleveret()
        {
           

            return View();
        }*/

        public ActionResult OrdreListe()
        {
            
            List<OrderModel> orders = new List<OrderModel>();
            
            OrderDAO orderDAO = new OrderDAO();

            orders = orderDAO.FetchOrder();

            return View("OrdreListe", orders);
        }

        public ActionResult Delete(int id)
        {
            OrderDAO orderDAO = new OrderDAO();
            orderDAO.Delete(id);
            List<OrderModel> orders = orderDAO.FetchOrder();

            return View("OrdreListe", orders);
        }

        public ActionResult Order0()
        {
            string departName = null;
            if (Session["Department"] != null)
            {

                departName = Session["Department"].ToString();
            }
            List<OrderModel> orders0 = new List<OrderModel>();

            OrderDAO orderDAO = new OrderDAO();

            orders0 = orderDAO.FetchOrder0(departName);

            return View("Order0", orders0);

        }
        /* public ActionResult UpdateOrder0(int id)
         {
             OrderDAO orderDAO = new OrderDAO();
             OrderModel order = orderDAO.UpdateOrder(id);
             return RedirectToAction("Order0", "HomeController", order);

         }*/
        public ActionResult UpdateOrder0(int id)
        {
            OrderDAO orderDAO = new OrderDAO();
            OrderModel order = orderDAO.FetchOneOrder(id);
            orderDAO.UpdateOrder(order);

            return RedirectToAction("Order0");
        }

        public ActionResult Order1()
        {
            string departName = null;
            if (Session["Department"] != null) 
            { 
            
            departName = Session["Department"].ToString();
            }
            List<OrderModel> orders1 = new List<OrderModel>();

            OrderDAO orderDAO = new OrderDAO();

            orders1 = orderDAO.FetchOrder1(departName);

            return View("Order1", orders1);

        }

       public ActionResult UpdateOrder1(int id)
        {
            OrderDAO orderDAO = new OrderDAO();
            OrderModel order = orderDAO.FetchOneOrder(id);
            orderDAO.UpdateOrder(order);
            return RedirectToAction("Order1");

        }

        public ActionResult Order2()
        {
            string departName = null;
            if (Session["Department"] != null)
            {

                departName = Session["Department"].ToString();
            }
            List<OrderModel> orders2 = new List<OrderModel>();

            OrderDAO orderDAO = new OrderDAO();

            orders2 = orderDAO.FetchOrder2(departName);

            return View("Order2", orders2);

        }
        public ActionResult NyOrdre()
        {
            // Det eneste denne actionresult skal gøre, er at vise en form. Den skal altså ikke være den der proccesor den nye ordre fra createorder.
            return View("NyOrdre");
        }

        public ActionResult ProcessNewOrder(OrderModel orderModel, HttpPostedFileBase file)
        {
          

            string imgName = Path.GetFileName(file.FileName);
            string imgExt = Path.GetExtension(imgName);
            string imgPath = "";
            if (imgExt == ".jpg" || imgExt == ".png")
            {
                imgPath = Path.Combine(Server.MapPath("~/Images"), imgName);
                file.SaveAs(imgPath);
            }

                OrderDAO orderDAO = new OrderDAO();
            orderDAO.CreateOrder(orderModel, imgName, imgExt, imgPath);

            return View("Details", orderModel);
        }

        public ActionResult Details(int id)
        {
            //For at få order fra databasen, så bliver man nødt til at lave en instance af databasen. Derfor:
            OrderDAO orderDAO = new OrderDAO();
            OrderModel order = orderDAO.FetchOneOrder(id);
            return View("Details", order);
        }
       
    }
}