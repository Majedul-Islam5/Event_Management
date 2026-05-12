using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCAppLayer.AuthFilter
{
    public class Logged : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var data = context.HttpContext.Session.GetString("UserName");
            if (data == null)
            {
                context.Result = new RedirectToActionResult("Login", "EventHub", null);
            }
        }
    }
}
