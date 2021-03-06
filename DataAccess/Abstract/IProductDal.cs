﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
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
        List<ProductDetailDto> GetProductDetails();
    }
}


//interfacelerin kendileri değil ama 
//operasyonları default PUBLIC tir. 