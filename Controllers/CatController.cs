using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAAAA.DAO;
using NLog;
using Microsoft.Ajax.Utilities;

namespace AAAAA.Controllers
{
    public class CatController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private Context context = new Context();
        // GET: Cat
        public ActionResult Index()
        {
            var catlist = (from c in context.CategoriesContext select c);
            #region use log4net
            //log.Debug("DEBUG");
            #endregion
            #region USE NLOG
            logger.Trace("trace message");
            #endregion
            return View(catlist);
        }

        // GET: Cat/Details/5
        public ActionResult Details(int? id)
        {
            Categories category = new Categories();
            if (id == null)
            {
                category = (from c in context.CategoriesContext where c.Id == id select c).FirstOrDefault();
            }
            else
            {
                category = (from t in context.CategoriesContext select t).FirstOrDefault();
            }
            return View(category);
        }

        // GET: Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
        [HttpPost]
        public ActionResult Create(Categories collection)
        {
            logger.Trace("debug message");
            try
            {
                context.CategoriesContext.Add(collection);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cat/Edit/5
        public ActionResult Edit(int id)
        {
            Categories cat = (from c in context.CategoriesContext where c.Id == id select c).FirstOrDefault();
            return View(cat);
        }

        // POST: Cat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categories collection)
        {
            try
            {
                Categories cat = null;
                cat = (from c in context.CategoriesContext where c.Id == collection.Id select c).FirstOrDefault();
                if (cat == null)
                {
                    return RedirectToAction("Error");
                }
                else
                {
                    SaveCategory(cat);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cat/Delete/5
        public ActionResult Delete(int id)
        {
            Categories cat = (from c in context.CategoriesContext where c.Id == id select c).FirstOrDefault();
            return View(cat);
        }

        // POST: Cat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Categories collection)
        {
            try
            {
                Categories cat = new Categories();
                cat = (from c in context.CategoriesContext where c.Id == collection.Id select c).FirstOrDefault();
                context.CategoriesContext.Remove(cat);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void SaveCategory(Categories cat)
        {
            if (cat.Id == 0)
            {
                context.CategoriesContext.Add(cat);
            }
            else
            {
                Categories catentry = context.CategoriesContext.Find(cat.Id);
                if (catentry != null)
                {
                    catentry.Name = cat.Name;
                    catentry.Description = cat.Description;
                    catentry.Rating = cat.Rating;

                }
            }
            context.SaveChanges();
        }
    }
}
