using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountsService(UserManager<User> userManager,
        IMapper mapper,
        IJwtService jwtService) : IAccountsService
    {

        private readonly UserManager<User> userManager = userManager;
        private readonly IMapper mapper = mapper;
        private readonly IJwtService jwtService = jwtService;
        //public AccountsService(UserManager<User> userManager)
        //{
        //    this.userManager = userManager;
        //}
        public async Task Register(RegisterDto model)
        {

            var User = new User
            {
                Email = model.Email,
                UserName = model.Email,
                Birthdate = model.Birthdate,
                PhoneNumber = model.PhoneNumber
            };

            var result = await userManager.CreateAsync(User, model.Password);
            if (!result.Succeeded)
            {
                //string all = string.Join(" ", result.Errors.Select(x => x.Description));
                var error = result.Errors.First();
                throw new HttpException(error.Description, HttpStatusCode.BadRequest);
            }
        }
        public async Task<LoginRespons> Login(LoginDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);

            return new LoginRespons
            {
                Token = jwtService.CreateToken(jwtService.GetClaims(user))
            };
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

    }
}
