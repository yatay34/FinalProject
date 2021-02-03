using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaraAccess.Abstract
{
    //30.01.2021 
 /*   public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId);
    }*/

    //Generic Repository Design Pattern ile  

    public interface IProductDal : IEntityRepository<Product>
    { 

    }
}


//interfacelerin kendileri değil ama 
//operasyonları default PUBLIC tir. 