using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AccountService:IAccountService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public AccountService(UserManager<AppUser> userManager ,
                              SignInManager<AppUser> signInManager, 
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper) 
        {
            _userManager= userManager;
            _signInManager= signInManager;
            _roleManager= roleManager;
            _mapper= mapper;
        
        }

        public async void Login(LoginDto loginVM)
        {
            
        }

        public async Task<IdentityResult> Register(RegisterDto registerVM)
        { 
            var newUser = _mapper.Map<AppUser>(registerVM);
            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);
            return result;
        }
    }
}
