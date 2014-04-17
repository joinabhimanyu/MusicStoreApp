using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MusicStoreApp.Models
{
    public class StoreManageEntitiesInitializer : DropCreateDatabaseIfModelChanges<StoreManagerEntities>
    {
        protected override void Seed(StoreManagerEntities context)
        {
            context.Products.Add(new Product
            {
                ProductID=1001,
                Name="Baseball Cap",
                Category="Sports Cap",
                Price=2020.10m,
                imgUrl="../Images/Jellyfish.jpg"
            });
            context.Products.Add(new Product
            {
                ProductID = 1010,
                Name = "Cricket Gloves",
                Category = "Sports Gloves",
                Price = 1050.60m,
                imgUrl="../Images/Koala.jpg"
            });
            context.Products.Add(new Product
            {
                ProductID = 1020,
                Name = "Football Shoe",
                Category = "Sports Shoe",
                Price = 3000.00m,
                imgUrl="../Images/Lighthouse.jpg"
            });
            base.Seed(context);
        }
    }
}