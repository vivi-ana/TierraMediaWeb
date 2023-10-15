using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TierraMediaWeb.Pages.Manage
{
	[Authorize(Policy = "Admin")]
	public class ManageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
