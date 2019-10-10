using System;
using System.Collections.Generic;
using HWProducts.Core.Model;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {

        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> category;

        public ProductCategoryRepository()
        { //cache is available till entire lifecyscle of the application
            category = cache["category"] as List<ProductCategory>; //take all the data from cache and store in products before going to the database
            if (category == null)
            {
                category = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["category"] = category; // commiting all products to the cache and not in the memory
        }

        public void Insert(ProductCategory p)
        {
            category.Add(p);
        }

        public void Update(ProductCategory c)
        {
            ProductCategory catToUpdate = category.Find(p => p.Id == c.Id);

            if (catToUpdate != null)
            {
                catToUpdate = c;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory cat = category.Find(p => p.Id == id);

            if (cat != null)
            {
                return cat;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return category.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory catToDelete = category.Find(p => p.Id == id);

            if (catToDelete != null)
            {
                category.Remove(catToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

    }
}
    