using HWProducts.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.DataAccess.SQL
{
    public class DataContext : DbContext //dbcontext is class of entity framework
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; } //dbset is collection for databases
        public DbSet<ProductCategory> ProductCategories { get; set; }

    }
}
