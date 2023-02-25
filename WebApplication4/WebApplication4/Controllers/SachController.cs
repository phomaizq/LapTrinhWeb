using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_Sach = from aa in data.Saches select aa;
            return View(all_Sach);
        }
        public ActionResult Detail(int id)
        {
            var D_Sach = data.Saches.Where(m => m.masach == id).First();
            return View(D_Sach);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Sach aa)
        {
            var ten = collection["tensach"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                aa.tensach = ten;
                data.Saches.InsertOnSubmit(aa);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        //-------------Edit-------------------
        public ActionResult Edit(int id)
        {
            var E_category = data.Saches.First(m => m.masach == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var sach = data.Saches.First(m => m.masach == id);
            var E_tensach = collection["tensach"];
                sach.masach = id;
            if (string.IsNullOrEmpty(E_tensach))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
               sach.tensach = E_tensach;
                UpdateModel(sach);
                data.SubmitChanges();
                return RedirectToAction("index");
            }
            return this.Edit(id);
        }
        //-------------Delete-------------------
        public ActionResult Delete(int id)
        {
            var D_Sach = data.Saches.First(m => m.masach == id);
            return View(D_Sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_Sach = data.Saches.Where(m => m.masach == id).First();
            data.Saches.DeleteOnSubmit(D_Sach);
            data.SubmitChanges();
            return RedirectToAction("index");
        }
    }
}