﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ReportWebApi.API.Models.LoginModels;
using ReportWebApi.Domain.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportWebApi.API.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Person> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<Person> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<bool> RegisterUser(LoginUser user)
        {
            var person = new Person
            {

                UserName = user.UserName,
                Email = user.Email,
                Id=Guid.NewGuid(),
               
            };

            var result = await _userManager.CreateAsync(person, user.Password);
            return result.Succeeded;
        }

        public async Task<bool> Login(LoginUser user)
        {
            var person = await _userManager.FindByEmailAsync(user.Email);
            if (person is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(person, user.Password);
        }

        public string GenerateTokenString(LoginUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.UserName),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}