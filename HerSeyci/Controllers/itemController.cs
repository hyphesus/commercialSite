﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HerSeyci.Models;


namespace WebAppECartDemo.Controllers
{
    public class ItemController : Controller
    {
        private ECartDBEntities objECartDbEntities;
        //public ItemController()
        //{
        //    objECartDbEntities = new ECartDBEntities();
        //}
        // GET: Item
        [HttpGet]
        public ActionResult Index()
        {
            return View();
            //ItemViewModel objItemViewModel = new ItemViewModel();
            //objItemViewModel.CategorySelectListItem = (from objCat in objECartDbEntities.Categories
            //    select new SelectListItem()
            //    {
            //        Text = objCat.CategoryName,
            //        Value = objCat.CategoryId.ToString(),
            //        Selected = true
            //    });
            //return View(objItemViewModel);
        }

        //[HttpPost]
        //public JsonResult Indexx(/*ItemViewModel objItemViewModel*/)
        //{
        //    //string NewImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.image.FileName);
        //    //objItemViewModel.image.SaveAs(Server.MapPath("~/Images/"+ NewImage));

        //    //Item objItem = new item();
        //    //objItem.ImagePath = "~/Images/" + NewImage;
        //    //objItem.CategoryId = objItemViewModel.category_id;
        //    //objItem.Description = objItemViewModel.description;
        //    //objItem.ItemId = Guid.NewGuid();
        //    //objItem.ItemName = objItemViewModel.name;
        //    //objItem.ItemPrice = objItemViewModel.price;
        //    //objECartDbEntities.items.Add(objItem);
        //    //objECartDbEntities.SaveChanges();

        //    //return Json(new {Success = true, Message = "Item is added Successfully."}, JsonRequestBehavior.AllowGet);
          
        //}
    }
}