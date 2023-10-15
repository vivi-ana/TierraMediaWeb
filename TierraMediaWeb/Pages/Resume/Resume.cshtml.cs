using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TierraMediaWeb.Pages.Resume
{
	[Authorize(Policy = "Client")]
	public class ResumeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
