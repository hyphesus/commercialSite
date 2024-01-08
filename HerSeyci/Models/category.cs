using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerSeyci.Models
{
    public class category
    {
        public int category_id { get; set; }
        public string name { get; set; }
        public string description { get; set;}
        public string parent_id { get; set; }
    }
}