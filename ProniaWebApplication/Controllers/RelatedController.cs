using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using ProniaWebApplication.DTOs.AcountDto;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Controllers
{
    public class RelatedController : Controller
    {
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;   

        public RelatedController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Account()
        {
            return View();
        }
        public IActionResult LoginRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginRegister(RegisterDto registerDto)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            User user = new User()
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                UserName=registerDto.Username
            };
             var result= await _userManager.CreateAsync(user,registerDto.Password);
            if(!result.Succeeded) {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult Compare()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
