using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerSeyci.Models
{
    public class account
    {
        public string Name { get; set; }
        public string Surename { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string E_posta { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }

    }
    

}