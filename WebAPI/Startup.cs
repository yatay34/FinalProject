using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //IoC...bana arka planda bir referans oluþtur.
            //IProductService tipinde bir baðýmlýlýðýn karþýlýðý ProductManager'dýr. 
            //eðer biri IProductService isterse ProductManager oluþturup ver 
            //Singleton--1 defa oluþturur.sonraki her talebe o instance ý gönderir
            //içinde data tutulmuyorsa Singleton kullanýlýr. (sepet uyg kullanýlmaz!!-herkesin sepeti birbirine girer)
            
            services.AddSingleton<IProductService, ProductManager>();
            services.AddSingleton<IProductDal, EfProductDal>();
             
            //Sadece injection için üst yöntem yetebilirdi ancak
            //AOP:AspectOrientedProgramming-
            //[LogAspect]:fonksiyonlarýn loglanmasý-[Validate][RemoveCache][Transaction][Performance]
            //IoC Container:
            //Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
