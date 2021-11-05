using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyMadModul.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int MemNumb { get; set; }

        public UserModel(int id, string name, string department, int memNumb)
        {
            Id = id;
            Name = name;
            Department = department;
            MemNumb = memNumb;

        }
    }
}