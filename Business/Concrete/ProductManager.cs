using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract; 
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;  
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
            if (DateTime.Now.Hour == 06)
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            /////Validation codes --doğrulama : yapısal uygunluk  CORE'a taşıdık. (CCC)
            ////var context = new ValidationContext<Product>(product);
            ////ProductValidator productValidator = new ProductValidator();
            ////var result = productValidator.Validate(context); 
            ////if(!result.IsValid)
            ////{
            ////    throw new FluentValidation.ValidationException(result.Errors);
            ////}  

            ////Loglama
            ////cache-remove
            ////performance
            ////transaction
            ////authorization - yetkilendirme 
            ////------bunların hepsinin buraya yazılması karmaşa getireceği için
            ////Cross-cutting-concerns'e başvurulur 

            //ValidationTool.Validate(new ProductValidator(), product);


            ///Business Codes - iş ihtiyaçlarımıza uygunluk

            _productDal.Add(product); 
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
