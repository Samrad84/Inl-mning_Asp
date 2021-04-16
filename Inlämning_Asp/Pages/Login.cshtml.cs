using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Inlämning_Asp.Models;
using Inlämning_Asp.Security;

namespace Inlämning_Asp.Pages
{
    public class LoginModel : PageModel
    {
        public string Msg;

        private SecurityManager securityManager = new SecurityManager();

        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password)
        {
            AccountModel accountModel = new AccountModel();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || accountModel.login(username, password) == null)
            {
                Msg = "Invalid";
                return Page();
            }
            else if (username == "User")
            {
                securityManager.SignIn(HttpContext, accountModel.find(username));
                return RedirectToPage("Events");
            }
            else
            {
                securityManager.SignIn(HttpContext, accountModel.find(username));
                return RedirectToPage("Add_Event");
                    
            }
        }
    }
}