using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaraAccess.Concrete.EntityFramework
{
    //Context : db tabloları ile proje classlarını bağlar, ilişkilendirir.

    public class NorthwindContext:DbContext
    {

        //projenin hangi db ile ilişkili olduğu belirtilir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ////kapadık: //base.OnConfiguring(optionsBuilder);
            //gerçekte: optionsBuilder.UseSqlServer(@"Server=175.45.2.12");

            ///Data Source=YASEMIN-PC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            ///XX/optionsBuilder.UseSqlServer(@"Server=YASEMIN-PC;Database:Northwind;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Data Source=YASEMIN-PC;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //Product  : prje classı
        //Products : db tablosu
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
