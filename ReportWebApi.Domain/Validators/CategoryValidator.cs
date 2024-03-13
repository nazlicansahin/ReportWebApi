using System;
using FluentValidation;
using ReportWebApi.Domain.Entities;

namespace ReportWebApi.Domain.Validators
{
	public class CategoryValidator:AbstractValidator<Category>
	{
		public CategoryValidator()
		{
            RuleFor(x => x.Name).NotNull().MaximumLength(255).WithMessage("Please At least write name");
        }

    }
}

