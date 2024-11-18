using compant.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserController> _ilogger;

        public UserController(UserManager<ApplicationUser> user,ILogger<UserController>Ilogger)
        {
            _userManager = user;
            _ilogger = Ilogger;
        }

        public async Task<IActionResult> Index(string searchInput)
        {

            if (searchInput == null)
            {
                List<ApplicationUser> res = await _userManager.Users.ToListAsync();
                return View(res);
            }
            List<ApplicationUser> res1 = await _userManager.Users.Where(users => users.NormalizedEmail.Trim().Contains(searchInput.Trim().ToUpper())).ToListAsync();
            return View(res1);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            return View(user); ;
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            ApplicationUser updateUser = await _userManager.FindByIdAsync(user.Id);
            updateUser.UserName = user.UserName;
            updateUser.NormalizedUserName = user.UserName.ToUpper();
            var res = await _userManager.UpdateAsync(updateUser);
            if (res.Succeeded)
            {
                _ilogger.LogInformation("user updated successfully");
                return RedirectToAction(nameof(Index));
            }
            _ilogger.LogInformation("user not updated ");
            return NotFound();
        }
    }
}
