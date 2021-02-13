using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract; 
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        /// bağımlılığı constuctor injection ile yapıyoruz.  
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 00)
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            return new SuccessDataResult<List<Product>>( _productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max), Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails() );
        }
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }
        
        public IResult Add(Product product)
        {
            ///Business Codes..here..
            ///
            if(product.ProductName.Length < 2)
            {
                //Magic strings 
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product); 
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
