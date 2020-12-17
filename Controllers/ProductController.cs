using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AAAAA.DAO;

namespace AAAAA.Controllers
{
    public class ProductController : Controller
    {
        private Context context = new Context();
        // GET: Product
        public ActionResult Index()
        {
            //работа с внешним ключом
            var products = context.ProductContext.Include(p => p.Category);
            return View(products.ToList());
        }
        

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            Product product = (from t in context.ProductContext where t.CategoryId == id select t).FirstOrDefault();
            ViewBag.CategoryId = context.CategoriesContext.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
            //ViewBag.cat = (from cat in context.CategoriesContext from pr in context.ProductContext where pr.CategoryId == cat.Id).FirstOrDefault();
            //return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            SelectList categories = new SelectList(context.CategoriesContext, "Id", "Name");

            ViewBag.CategoryId = categories;

            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product collection)
        {
            if (ModelState.IsValid)
            {
                context.ProductContext.Add(collection);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = context.ProductContext.Find(id);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product collection)
        {
            int a = 0;
            try
            {
                Product pr = new Product();
                pr = context.ProductContext.Find(id);
                if (pr != null)
                {
                    pr.id = collection.id;
                    pr.Name = collection.Name;
                    pr.Description = collection.Description;
                    pr.CategoryId = collection.CategoryId;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = (from c in context.ProductContext where c.id == id select c).FirstOrDefault();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                Product product = context.ProductContext.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    context.ProductContext.Remove(product);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
