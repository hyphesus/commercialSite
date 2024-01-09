using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerSeyci.Models
{
    public class account
    {
        public account()
        {
            Name = "-";
            Surename = "-";
            User_name = "-";
            Password = "-";
            Password2 = "-";
            E_posta = "-";
            Adress1 = "-";
            Adress2 = "-";
            Phone = "-";
            IsAdmin = false;
        }

        public string Name { get; set; }
        public string Surename { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string E_posta { get; set; }
        public string Adress1 { get; set; }
        public string Adress2 { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
    }


}