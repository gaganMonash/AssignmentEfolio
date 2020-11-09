using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.ViewModels
{
    public class EmailViewModel
    {
       public  String emailFrom { get; set; }
        public String emailTo { get; set; }


        public List<String> emailToAll { get; set; }
        public String Body { get; set; }
        public String Subject { get; set; }


    }


}