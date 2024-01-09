using HerSeyci.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HerSeyci.Controllers
{
    public class KartOlusturmaController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void connectionString()
        {
            con.ConnectionString = "data source=.;database=e_dukkandatabase; integrated security=SSPI;";

        }


        // GET: KartOlusturma

        [HttpGet]
        public ActionResult Giyisi()
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM products where category_id=1";
            dr = com.ExecuteReader();


            List<products> giyim = new List<products>();


            while (dr.Read())
            {
                var productx = new products()
                {
                    product_id = Convert.ToInt32(dr["product_id"]),
                    name = dr["name"].ToString(),
                    description = dr["description"].ToString(),
                    price = Convert.ToInt32(dr["price"]),
                    stock = dr["stock"].ToString()=="True" ? "Var" : "Yok",
                    category_id = Convert.ToInt32(dr["category_id"]),
                    img_url = dr["img_url"].ToString()
                };

                    giyim.Add(productx);


            }

                con.Close();
                return View(giyim);



        }


        [HttpGet]
        public ActionResult Elektronik()
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM products where category_id=2";
            dr = com.ExecuteReader();

            List<products> elektronik = new List<products>();


            while (dr.Read())
            {
                var productx = new products()
                {
                    product_id = Convert.ToInt32(dr["product_id"]),
                    name = dr["name"].ToString(),
                    description = dr["description"].ToString(),
                    price = Convert.ToInt32(dr["price"]),
                    stock = dr["stock"].ToString() == "True" ? "Var" : "Yok",
                    category_id = Convert.ToInt32(dr["category_id"]),
                    img_url = dr["img_url"].ToString()
                };

                    elektronik.Add(productx);

            }

                con.Close();
                return View(elektronik);



        }


        [HttpGet]
        public ActionResult Kozmetik()
        {

            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM products where category_id=3";
            dr = com.ExecuteReader();

            List<products> kozmetik = new List<products>();


            while (dr.Read())
            {
                var productx = new products()
                {
                    product_id = Convert.ToInt32(dr["product_id"]),
                    name = dr["name"].ToString(),
                    description = dr["description"].ToString(),
                    price = Convert.ToInt32(dr["price"]),
                    stock = dr["stock"].ToString() == "True" ? "Var" : "Yok",
                    category_id = Convert.ToInt32(dr["category_id"]),
                    img_url = dr["img_url"].ToString()
                };

                    kozmetik.Add(productx);

            }

                con.Close();
                return View(kozmetik);



        }


    }
}