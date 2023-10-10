using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TierraMediaWeb.Data;

namespace TierraMediaWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly AplicationDbContext _context;
        public LoginModel(AplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserCredential UserCredential { get; set; }
        public async Task<UserCredential> AuthenticateUser(string username, string password)
        {
            var succeeded = await _context.UserCredential.FirstOrDefaultAsync(authUser => authUser.User == username && authUser.Password == password);
            return succeeded;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var issuccess = AuthenticateUser(UserCredential.User, UserCredential.Password);
            if (!ModelState.IsValid) return Page();
            if (issuccess.Result != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebside.com")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");

            }
            else 
            { 
                ViewData["ErrorMessage"] = "You can't log in. Please check your credentials.";
                return Page();
            }
        }
    }
}
public class UserCredential
{
    [Key]
    public string? Id { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public string User { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public string Password { get; set; }
    public int Role { get; set; }
}
