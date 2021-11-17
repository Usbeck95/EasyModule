using EasyMadModul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using EasyMadModul.Services.Business;

namespace EasyMadModul.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(DepartmentModel departmentModel)
        {
            /* return "Results: Department = " + departmentModel.Department + " PW = " + departmentModel.Password ;*/

        // laver en reference til securityservice og securityservice returnerer en værdi: Authenticate. Og authenticate er en boolean. så entet lykkedes det at logge ind ellers ikke. 
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(departmentModel);

            if (success)
            {
                return View("LoginSuccess", departmentModel);
            }
            else
            {
                return View("LoginFail");
            }
        }
    }
}