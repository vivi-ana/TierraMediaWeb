using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TierraMediaWeb.Pages
{
	[Authorize(Policy = "AdminOrClient")]
	public class UsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
