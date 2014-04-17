using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MusicStoreApp.Models
{
    public class Product
    {
        public virtual int ProductID { get; set; }

        [Display(Name="Product Name")]
        public virtual string Name { get; set; }

        [Display(Name="Product Category")]
        public virtual string Category { get; set; }

        [Display(Name="Product Price")]
        public virtual decimal Price { get; set; }

        public virtual string imgUrl { get; set; }
    }
}