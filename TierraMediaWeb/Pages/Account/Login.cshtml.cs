using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            var userCredential = await _context.UserCredential.FirstOrDefaultAsync(authUser => authUser.User == username && authUser.Password == password);
			return userCredential;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var userCredential = AuthenticateUser(UserCredential.User, UserCredential.Password);
            if (!ModelState.IsValid) return Page();
            if (userCredential!= null)
            {
				var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userCredential.Result.User),
                    new Claim(ClaimTypes.Role, userCredential.Result.Role.ToString())
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
