using Business.Concrete;
using DaraAccess.Concrete.EntityFramework;
using DaraAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    //SOLID
    //O: Open-Closed Principle
    /// <summary>
    /// Yaptığım yazılıma yeni bir özellik ekliyorsan mevcuttaki hiçbir koda dokunamazsın
    /// sadece konfigurasyonu değiştirirsin. 
    /// >>> veri erişimini Memory'den EF ye taşıdık.  
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        { 
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());
            
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice); 
            }

            Console.WriteLine("------------------------");

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }

            Console.WriteLine("------------------------");

            foreach (var product in productManager.GetByUnitPrice(100, 500))
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }
            Console.WriteLine("Hello World!"); 
        }
    }
}
