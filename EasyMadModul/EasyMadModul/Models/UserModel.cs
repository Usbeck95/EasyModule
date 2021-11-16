using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMadModul.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
       
        public SelectList Departmentlist { get; set; }

        public UserModel(int id, string name, int departmentId)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
           

        }

        public UserModel()
        {
        }
    }
}