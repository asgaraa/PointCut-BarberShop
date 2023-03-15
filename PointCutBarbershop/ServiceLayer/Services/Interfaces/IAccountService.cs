using Microsoft.AspNetCore.Identity;
using ServiceLayer.DTOs.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IAccountService
    {
        void Login(LoginDto loginDto);

        Task<IdentityResult> Register(RegisterDto registerDto);
    }
}
