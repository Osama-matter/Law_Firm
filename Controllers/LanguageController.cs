using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.WebUtilities;

namespace Law_Firm.Controllers
{
    public class LanguageController : Controller
    {
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            // Ensure QueryString provider sees culture on the redirected URL
            var withCulture = QueryHelpers.AddQueryString(returnUrl ?? "~/", new Dictionary<string, string?>
            {
                ["culture"] = culture,
                ["ui-culture"] = culture
            });

            return LocalRedirect(withCulture);
        }
    }
}
