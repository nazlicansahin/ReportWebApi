using System;
using FluentValidation;
using ReportWebApi.API.Models.PostViewModels;

namespace ReportWebApi.API.Models.Validators
{
	public class AuthValidator:AbstractValidator<AuthPostModel>
	{
		public AuthValidator()
		{
			
		}
	}
}

