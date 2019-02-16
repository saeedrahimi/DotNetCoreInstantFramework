using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebPages.Pages
{
    [Authorize(Roles = "admin")]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}