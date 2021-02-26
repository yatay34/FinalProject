using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //throw new System.Exception(AspectMessages.WrongValidationType);
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            ///Reflection-çalışma anında bişeyleri çalıştırmayı sağlar-PrductValidatorın bir instance ını oluşturur.
            var validator = (IValidator)Activator.CreateInstance(_validatorType); 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//PrductValidator'ın BaseType'inin çalıştığı Generic Args(0):veri tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//invocation:Method, çalıştığın methodun parametrelerinin bul
            //Validatorun tipine (Prduct) eşit olan parametreleri bul
            //-PrductValidator Prduct ile çalışıyr, işleme tabi tutulacak methdun(Add) Prduct tipindeki parametrelerni al
            
            foreach (var entity in entities)  
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
