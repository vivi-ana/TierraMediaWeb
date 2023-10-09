using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TierraMediaWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserCredential UserCredential { get; set; }
        public void OnGet()
        {
        }
        public void OnPost() 
        {
        }
    }
    public class UserCredential
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string User { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
        public int Role { get; set; }
    }

}
