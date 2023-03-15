using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.Services.Interfaces;
using System.Net.Mail;
using System.Security.Claims;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _service;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<AppUser> userManager, 
                                 SignInManager<AppUser> signInManager, 
                                 RoleManager<IdentityRole> roleManager,
                                 IAccountService service,
                                 IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _service = service;
            _emailService= emailService;
        }

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            AppUser user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);

            }

            if (user is null)
            {
                ModelState.AddModelError("", "Email or Password is Wrong");
                return View(loginVM);
            }

         

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Please Confirm Your Accaunt");
                    return View(loginVM);
                }
                ModelState.AddModelError("", "Email or Password is Wrong");
                return View(loginVM);
            }

            if (User.FindFirstValue(ClaimTypes.Role) == "User")
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Dashboard", "AdminArea");
            }

          
        }
        #endregion


        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDto registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var result = await _service.Register(registerVM);

           

          
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View(registerVM);
            }


            if (string.IsNullOrWhiteSpace(registerVM.Email))
            {
                return RedirectToAction("Index", "Error");
            }
            AppUser appUser = await _userManager.FindByEmailAsync(registerVM.Email);

            if (appUser == null)
                return RedirectToAction("Index", "Error");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = appUser.Id, token = code }, Request.Scheme, Request.Host.ToString());

            await _emailService.ConfirmEmail(appUser, link);





            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region VerifyEmail
        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            if (userId == null || token == null) return BadRequest();

            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user is null) return BadRequest();


            await _userManager.ConfirmEmailAsync(user, token);

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Dashboard");
        }
        #endregion

    }
}
