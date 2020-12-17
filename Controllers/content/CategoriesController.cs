using LOGLIBRARY.MYFLOIDER;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace AAAAA.Controllers.content
{
    public class CategoriesController : Controller
    {
        CRUDOperations.CRUDCATEGORIES crud = new CRUDOperations.CRUDCATEGORIES();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Categories
        public ActionResult Index()
        {
            var categories = crud.GetAlCategories();
            logger.Debug("index method is call");
            return View(categories);
        }
        
        public ActionResult Details(int? id)
        {
            Categories categ = crud.GetCategoryById(id);
            if (categ == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(categ);
            }

        }
        [HttpPost]
        public ActionResult Create(Categories categ)
        {
            if (ModelState.IsValid)
            {
                crud.AddCategory(categ);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(int id,  Categories cat)
        {
            if (crud.UpdateCategories(cat.Id, cat))
            {
                return RedirectToAction("Index");
            }
           else
            {
                return View();
            }
        }
        public ActionResult Update(int id)
        {
            Categories cat = crud.GetCategoryById(id);
            return View(cat);
        }
        public ActionResult Delete(int id)
        {
            Categories cat = crud.GetCategoryById(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Delete(Categories cat)
        {
            crud.RemoveCategory(cat);
            return RedirectToAction("Index");
        }
    }
}