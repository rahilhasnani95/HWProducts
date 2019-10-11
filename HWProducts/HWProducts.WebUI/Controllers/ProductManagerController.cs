using HWProducts.Core.Contracts;
using HWProducts.Core.Model;
using HWProducts.Core.ViewModel;
using HWProducts.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HWProducts.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: ProductManager
        //InMemoryRepository<Product> context;
        //InMemoryRepository<ProductCategory> productCategories;
        //changed from class repository to interface

        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;

        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> categoryContext)
        {
            //context = new InMemoryRepository<Product>();
            //productCategories = new InMemoryRepository<ProductCategory>();
            context = productContext;
            productCategories = categoryContext;
        }

        public ActionResult Index()
        {
            List<Product> products= context.Collection().ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductManagerViewModel vm = new ProductManagerViewModel();
            vm.Product = new Product();
            vm.productCategories = productCategories.Collection();
            //Product product = new Product();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {

                if(file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//" + product.Image));
                }

                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            Product product = context.Find(id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {

                ProductManagerViewModel vm = new ProductManagerViewModel();
                vm.Product = product;
                vm.productCategories = productCategories.Collection();
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, string id, HttpPostedFileBase file)
        {
            //context.Update(product);
            //context.Commit();
            //return RedirectToAction("Index");
            Product productToFind = context.Find(id);
            if (productToFind == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                if (file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//" + product.Image));
                }
                productToFind.Image = product.Image;
                productToFind.Category = product.Category;
                productToFind.Price = product.Price;
                productToFind.Description = product.Description;
                productToFind.Name = product.Name;

                context.Commit();
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Product productToDelete = context.Find(id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
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