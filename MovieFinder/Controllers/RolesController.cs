using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieFinder.Models;
using MovieFinder.Models.Forms;

namespace MovieFinder.Controllers
{

    
    public class RolesController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RolesController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ShowRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole()
        {
            return View(new RoleForm());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromForm] RoleForm form)
        {

            var newRoleName = form.Name;
            
                var newRole = new IdentityRole<int>();
                newRole.Name = newRoleName;
                await _roleManager.CreateAsync(newRole);
            
            return RedirectToAction("ShowRoles");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var roleToDelete = await _roleManager.FindByIdAsync(id.ToString());
            if (roleToDelete != null)
            {
                await _roleManager.DeleteAsync(roleToDelete);
            }
            return RedirectToAction("ShowRoles");
        }
    }
}
