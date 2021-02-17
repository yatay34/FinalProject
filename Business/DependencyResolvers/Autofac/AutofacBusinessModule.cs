using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module //sen bir autofac modulüsün
    {
        protected override void Load(ContainerBuilder builder)
        {
            ///startup: services.AddSingleton<IProductService, ProductManager>();
            ///.SingleInstance() - tek bir instance oluşturur, isteyene onu verir
            
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();  
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();  
 

        }
    }
}
