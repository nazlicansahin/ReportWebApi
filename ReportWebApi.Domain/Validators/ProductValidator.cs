using System;
using FluentValidation;
using ReportWebApi.Domain.Entities;

namespace ReportWebApi.Domain.Validators
{
	public class ProductValidator:AbstractValidator<Product>
	{
		public ProductValidator()
		{
            

            RuleFor(p => p.Name)
                .Null()
                .MaximumLength(255);

            RuleFor(p => p.Image)
                .Null()
                .MaximumLength(255);

            RuleFor(p => p.Description)
                 .Null()
                .MaximumLength(1000);

            RuleFor(p => p.Price)
                .Null();

            RuleFor(p => p.ProductState)
                .NotNull();


            RuleFor(p => p.SellerId)
                .Null()
                .MaximumLength(255);
        }
	}
}

