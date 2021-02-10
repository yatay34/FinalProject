using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
            //ProductTest();
            //CategoryTest();
            //ProductDetailsDtoTest();  

            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetAll();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
                }
            }
            else
                Console.WriteLine(result.Message);
            
            

        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }

            Console.WriteLine("------------------------");

            foreach (var product in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }

            Console.WriteLine("------------------------");

            foreach (var product in productManager.GetByUnitPrice(100, 500).Data)
            {
                Console.WriteLine(product.ProductName + " - " + product.UnitPrice);
            }
            Console.WriteLine("Hello World!");
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
               Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductDetailsDtoTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " - " + product.CategoryName);
                } 
            } 
            else
            { 
                Console.WriteLine(result.Message);
            }

            Console.WriteLine("------------------------");
        }
    }
}
