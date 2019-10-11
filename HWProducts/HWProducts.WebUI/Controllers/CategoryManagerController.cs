using HWProducts.Core.Contracts;
using HWProducts.Core.Model;
using HWProducts.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWProducts.WebUI.Controllers
{
    public class CategoryManagerController : Controller
    {
        // GET: ProductManager
        IRepository<ProductCategory> context;

        public CategoryManagerController(IRepository<ProductCategory> categoryContext)
        {
            context = categoryContext;
        }

        public ActionResult Index()
        {
            List<ProductCategory> category= context.Collection().ToList();
            return View(category);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductCategory category = new ProductCategory();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory cat)
        {
            if(!ModelState.IsValid)
            {
                return View(cat);
            }
            else
            {
                context.Insert(cat);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ProductCategory cat = context.Find(id);
            if(cat == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(cat);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory cat, string id)
        {
            //context.Update(product);
            //context.Commit();
            //return RedirectToAction("Index");
            ProductCategory catToFind = context.Find(cat.Id);
            if (catToFind == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(cat);
                }
                catToFind.Category = cat.Category;

                context.Commit();
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            ProductCategory catToDelete = context.Find(id);
            if (catToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(catToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
                context.Delete(id);
                context.Commit();
                return RedirectToAction("Index");

        }


    }
}