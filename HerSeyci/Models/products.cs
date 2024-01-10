using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerSeyci.Models
{
    public class products
    {
        public int product_id { get; set; }
        public string name { get; set; }
        public string description { get; set;}
        public int price { get; set; }
        public string stock { get; set; }
        public int category_id { get; set; }
        public string img_url { get; set; }
        public string category{ get; set; }



    }
}