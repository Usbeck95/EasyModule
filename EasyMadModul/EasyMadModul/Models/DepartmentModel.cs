using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMadModul.Models
{
    public class DepartmentModel
    {
        public DepartmentModel()
        {
        }

        public DepartmentModel(int id, string department, string password)
        {
            Id = id;
            Department = department;
            Password = password;
        }

        public int Id { get; set; }
        public string Department { get; set; }

        public string Password { get; set; }
    }
}