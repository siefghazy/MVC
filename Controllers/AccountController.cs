using compant.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManagment;
        private readonly SignInManager<ApplicationUser> userSignIn;

        public AccountController(UserManager<ApplicationUser> _user, SignInManager<ApplicationUser> signIn)
        {
            userManagment = _user;
            userSignIn = signIn;
        }

        [HttpGet]
        public IActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    firstName = model.firstName,
                    lastName = model.LastName,
                    isActive = true
                };
                var res = await userManagment.CreateAsync(user, model.password);
                if (res.Succeeded)
                {
                    return RedirectToAction("signIn");
                }
                foreach (var err in res.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult signIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signIn(logInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkUser = await userManagment.FindByEmailAsync(model.Email);
                var checkUserPassword = await userManagment.CheckPasswordAsync(checkUser,model.password);
                if (checkUser is not null && checkUserPassword != false)
                {
                    var res = await userSignIn.PasswordSignInAsync(checkUser, model.password, model.rememberMe, false);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "invalid login");
                return RedirectToAction(nameof(signIn));
            }
            return RedirectToAction(nameof(signIn));
        }
        public async Task<IActionResult> SignOut()
        {
            await userSignIn.SignOutAsync();
            return RedirectToAction("signIn");
        }
    }
}
