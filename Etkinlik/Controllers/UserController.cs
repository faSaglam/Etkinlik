using Business.Abstract;

using Entities.Concreate;
using Entities.Concreate.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        public UserController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<UserRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (ModelState.IsValid) 
            {
                var user = new User
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PasswordHash = model.Password
                };
                var userNameControl = await _userManager.FindByEmailAsync(user.Email);
                if(userNameControl != null)
                {
                    ViewBag.Error = "Böyle bir kullanıcı zaten var.";
                    return View(model);
                }
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userRole = _roleManager.FindByNameAsync("User").Result;
                    if (userRole != null)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, userRole.Name);

                    }
                    result.Errors.ToList().ForEach(error => ModelState.AddModelError(string.Empty, error.Description));
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != null)
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync(); // önceki oturumdan kalma user bilgileri
                    var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, true);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        var returnUrl = TempData["ReturnUrl"];
                        if (returnUrl != null)
                        {
                            return Redirect(returnUrl.ToString() ?? "/");

                        }
                        return RedirectToAction("List", "Event");
                    }
                    else if (result.IsLockedOut)
                    {
                        var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;
                        ModelState.AddModelError(string.Empty, $"Lütfen {timeLeft.Minutes} sonra tekrar deneyin");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Yanlış şifre veya e-posta.");

                    }


                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Yanlış şifre veya e-posta.");
                }
            }
            return View(viewModel);

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IActionResult> Update()
        {
            var user = await _userManager.GetUserAsync(User);
            UserUpdateDTO userUpdate = new UserUpdateDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,


            };

            return View(userUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> Update(string FirstName , string LastName , string Email)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NoContent();
            }
   
         
            var user = await _userManager.FindByIdAsync(userId);
            user.Email = Email;
            user.UserName= Email;
            user.FirstName = FirstName;
            user.LastName = LastName;
            await _userManager.UpdateAsync(user);
      
            return RedirectToAction("Profile");
        }
        public async Task<IActionResult> UpdatePassword(UserPasswordUpdateDTO userPasswordUpdateDTO)
        {
            return View(userPasswordUpdateDTO);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(string oldPassword , string newPassword)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NoContent();
            }

            
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!result.Succeeded)
            {
                TempData["UpdatePassword"] = "Eski şifreniz yanlış veya Yeni şifreniz istenilen kurallara uymuyor:Şifre en az 8 karakter olmalıdır.En az bir büyük , bir küçük harf ve rakam içermelidir.";
                return View();
            }
            if (result.Succeeded)
            {
                TempData["UpdatePassword"] = "Şifreniz güncellendi";
            }
            return  View();
        }
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            UserProfileDTO profile = new UserProfileDTO()
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };
            return View(profile);
        }
    }
}
