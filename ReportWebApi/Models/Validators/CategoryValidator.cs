using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using ReportWebApi.API.Models.PostModels;
using ReportWebApi.Domain.Entities;

namespace ReportWebApi.API.Validators
{
	public class CategoryPostValidator:AbstractValidator<CategoryPostModel>
	{
		public CategoryPostValidator()
		{
            RuleFor(x => x.Name)
       .NotEmpty().WithMessage("Please write a name")
       .MaximumLength(255).WithMessage("Name cannot exceed 255 characters");

        }
    }
}

