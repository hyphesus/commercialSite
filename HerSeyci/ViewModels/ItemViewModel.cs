using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Models
{
   
    public class ItemViewModel
    {

        public int product_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public int category_id { get; set; }
        public string img_url { get; set; }
        public HttpPostedFile image { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}