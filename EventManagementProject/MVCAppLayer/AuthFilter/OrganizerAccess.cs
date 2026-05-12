using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCAppLayer.AuthFilter
{
    public class OrganizerAccess : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var data = context.HttpContext.Session.GetInt32("UserRole");
            if (data != 1)
            {
                context.Result = new RedirectToActionResult("Login", "EventHub", null);
            }
        }
    }
}
