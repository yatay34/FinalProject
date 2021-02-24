﻿using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            ////var context = new ValidationContext<Product>(product);
            ////ProductValidator productValidator = new ProductValidator();
            ////var result = productValidator.Validate(context);
            ////if (!result.IsValid)
            ////{
            ////    throw new FluentValidation.ValidationException(result.Errors);
            ////}

            var context = new ValidationContext<object>(entity); 
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }

        }
    }
}
