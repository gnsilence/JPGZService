using Microsoft.AspNetCore.Antiforgery;
using JPGZService.Controllers;

namespace JPGZService.Web.Host.Controllers
{
    public class AntiForgeryController : JPGZServiceControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
