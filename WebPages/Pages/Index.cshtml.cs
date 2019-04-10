using Core.Domain.Contract.Services.Application.Identity;
using Core.Domain.Contract.Services.Application.Identity.Model;
using Core.Domain.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace WebPages.Pages
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        public IndexModel(IIdentityService identityService)
        {
            identityService.SignUp(new SignUpModel() { });
        }

        public void OnGet()
        {
        
        }
    }
}
