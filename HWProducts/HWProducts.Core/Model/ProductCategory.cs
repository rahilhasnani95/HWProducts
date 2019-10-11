using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Model
{
    public class ProductCategory : BaseEntity
    {
        //since its repeated we put in abstract class
        //public string Id { get; set; }
        public string Category { get; set; }

        //since its repeated we put in abstract class
        //public ProductCategory()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
