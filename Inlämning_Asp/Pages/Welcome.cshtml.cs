using Inlämning_Asp.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Inlämning_Asp.Data;

namespace Inlämning_Asp.Pages
{
    [Authorize(Roles = "user,admin,organizer")]
    public class WelcomeModel : PageModel
    {
        public string UserId;

        private SecurityManager securityManager = new SecurityManager();

        public void OnGet()
        {
            UserId = User.FindFirst(ClaimTypes.Name).Value;
        }

        public IActionResult OnGetLogout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToPage("Login");
        }
    }
}