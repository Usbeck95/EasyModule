using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMadModul.Models
{
    public class DepartmentModel
    {
        public DepartmentModel(int id, string department)
        {
            Id = id;
            Department = department;
        }

        public int Id { get; set; }
        public string Department { get; set; }
    }
}