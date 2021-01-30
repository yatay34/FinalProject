using DaraAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaraAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        //Oracle, SqlServer, Postgres, MongoDb den geliyormuş gibi simule ediyoruz...
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
                new Product{ProductId=2, CategoryId=1, ProductName="Termos", UnitPrice=100, UnitsInStock=10 },
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=5000, UnitsInStock=9 },
                new Product{ProductId=4, CategoryId=2, ProductName="Bilgisayar", UnitPrice=7000, UnitsInStock=7 },
                new Product{ProductId=5, CategoryId=2, ProductName="Tablet", UnitPrice=2500, UnitsInStock=5 },
                new Product{ProductId=6, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
                new Product{ProductId=7, CategoryId=2, ProductName="Fare", UnitPrice=50, UnitsInStock=1 },  
            };     
        }


        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        //LINQ = Language Integrated Query
        //=> Lambda
        public void Delete(Product product)
        {
            //_products.Remove(product); ///XXX ref tipleri bu şekilde silemeyiz!!

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock; 
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
