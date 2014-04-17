
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

namespace MusicStoreApp.Models
{
    public class StoreManagerEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
