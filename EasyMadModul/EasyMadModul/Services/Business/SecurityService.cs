using EasyMadModul.Models;
using EasyMadModul.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMadModul.Services.Business
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();
        // så jeg laver en metode kaldet authenticate, som skal kigge efter, om man er den departmen, som man siger, man er.
        public bool Authenticate(DepartmentModel department)
        {
          

            return daoService.FindByDepartment(department);
        }
    }
}