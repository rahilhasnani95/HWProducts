﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWProducts.Core.Model
{
    public class Product : BaseEntity
    {
        //since its repeated we put in abstract class
       // public string Id { get; set; }

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        //since its repeated we put in abstract class
        //public Product()
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}


    }
}
