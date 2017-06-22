using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using crud.Models;

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(crud.Models.SelectModel selectmodel)
        {
               
            DataSet ds = selectmodel.GetAllTable2();
            ViewBag.Table2 = ds.Tables[0];
            return View();
        }


        //[HttpGet]
        //public ActionResult Add()
        //{
        //    return View();
        //}
        //[HttpPost]
        public ActionResult Add(crud.Models.InsertModel insertmodel)
        {   
            
            if (ModelState.IsValid)
            {
                int _records = insertmodel.Insert(insertmodel.name, insertmodel.age);
                if (_records > 0)
                {
                    return RedirectToAction("Add", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Insert");
                }
            }
            return View(insertmodel);
        }

        [HttpGet]
        public ActionResult Edit(crud.Models.UpdateModel updatemodel)
        {
            SqlConnection con = new SqlConnection("Data Source=DD-PC;Initial Catalog=DB_VINAYAK;User Id=sa;Password=123;");
            SqlCommand c = new SqlCommand("select * from Table2", con);
            con.Open();
            SqlDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                updatemodel.id = Convert.ToInt32(dr["id"].ToString());
                updatemodel.name = dr["name"].ToString();
                updatemodel.age = Convert.ToInt32(dr["age"].ToString());
            }
            else
            {
                dr.Close();
            }
            dr.Close();
            con.Close();
            return View(updatemodel);
        }
                
        [HttpPost]
        public ActionResult Upfate()
        {
         UpdateModel updatemodel=new UpdateModel();
           
            if (ModelState.IsValid)
            {
                int _records = updatemodel.Update(Request.Form["id"], Request.Form["name"], Request.Form["age"]);
                if (_records > 0)
                {

                    return RedirectToAction("Edit", "Home");
                }
                {
                    ModelState.AddModelError("", "Can Not Update");
                }
            }
            return View(updatemodel);
        }

        
        public ActionResult Delete(int id, crud.Models.delete deletemodel)
        {
           
            int records = deletemodel.Delete(id);
            if (records > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Can Not Delete");
                return View("Index");
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}