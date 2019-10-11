using HWProducts.Core.Contracts;
using HWProducts.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.DataAccess.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity //where T is type of BaseEntity, it can be anything product or category or order etc
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;
        public InMemoryRepository()
        { //cache is available till entire lifecyscle of the application
            className = typeof(T).Name; //different data will b stored in different cache of classNames
            items = cache[className] as List<T>; //take all the data from cache and store in products before going to the database
            if(items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[className] = items; // commiting all products to the cache and not in the memory
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);

            if(tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + " Not Found");
            }
        }

        public T Find(string id)
        {
            T t = items.Find(i => i.Id == id);

            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " Not Found");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            T tToDelete = items.Find(i => i.Id == id);

            if (tToDelete != null)
            {
                items.Remove(tToDelete);
            }
            else
            {
                throw new Exception(className + " Not Found");
            }
        }

    }
}
