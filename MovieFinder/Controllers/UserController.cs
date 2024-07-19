using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;
using MovieFinder.Models.Forms;
using System.Diagnostics;
using System.Security.Claims;

namespace MovieFinder.Controllers
{
    
    public class UserController : Controller
    {
       
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserController(UserManager<User> manager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = manager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Register(string? returnUrl)
        {
            return View(new RegisterForm());
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterForm form, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            if (form.Password != form.ConfirmPassword)
            {
                ModelState.AddModelError(nameof(form.ConfirmPassword), "?????? ??????? ??????????");
                return View(form);
            }

            var user = await _userManager.FindByEmailAsync(form.Login);
            if (user != null)
            {
                ModelState.AddModelError(nameof(form.Login), "?????????? ? ????? ?????? ??? ?????");
                return View(form);
            }
            user = new User
            {
                Email = form.Login,
                UserName = form.Login,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, form.Password);

            await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
            {
                ModelState.AddModelError(nameof(form.Login), string.Join(";", result.Errors.ToList().Select(x => x.Description)));
            }

            await SignIn(user);


            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }



            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task SignIn(User user)
        {
            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, role);
                identity.AddClaim(roleClaim);
            }

            await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Login(string? returnUrl)
        {
            return View(new LoginForm());
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginForm form, string? returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(form);
            }
            var user = await _userManager.FindByEmailAsync(form.Login);
            if (user == null)
            {
                ModelState.AddModelError(nameof(form.Login), "?????????? ?? ?????");
                return View(form);
            }

            if (!await _userManager.CheckPasswordAsync(user, form.Password))
            {
                ModelState.AddModelError(nameof(form.Password), "???????? ??????");
                return View(form);
            }

            await SignIn(user);

            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ShowUsers()
        {
            var users = _userManager.Users.ToList();
           
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);

            return RedirectToAction("ShowUsers");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            ViewData["user"] = user;
            var allRoles = _roleManager.Roles.ToList();
            var userRolesToView = new UserRolesForm();
            foreach (var role in allRoles)
            {
                var roleToView = new UserRoleForm() { Id = role.Id, Name = role.Name };

                roleToView.IsActive = await _userManager.IsInRoleAsync(user, role.Name);

                userRolesToView.UserRoles.Add(roleToView);
            }
            return View(userRolesToView);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersRole(int id, [FromForm] UserRolesForm form)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in form.UserRoles)
            {
                if (role.IsActive)
                {
                    if (!await _userManager.IsInRoleAsync(user, role.Name))
                        await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
            return RedirectToAction("ShowUsers", "User");
        }


    }
}
