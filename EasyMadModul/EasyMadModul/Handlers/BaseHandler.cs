using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace EasyMadModul.Handlers
{
    public class BaseHandler
    {
        
       
        public BaseHandler()
        {
            //connection to database
            string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            
        }
    }
}
