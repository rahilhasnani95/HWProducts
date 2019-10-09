using HWProducts.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        { //cache is available till entire lifecyscle of the application
            products = cache["products"] as List<Product>; //take all the data from cache and store in products before going to the database
            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products; // commiting all products to the cache and not in the memory
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);

            if(productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public Product Find(string id)
        {
            Product product = products.Find(p => p.Id == id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string id)
        {
            Product productToDelete = products.Find(p => p.Id == id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

    }
}
