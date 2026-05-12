using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCAppLayer.AuthFilter
{
    public class AttendeeAccess : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var data = context.HttpContext.Session.GetInt32("UserRole");
            if (data != 3)
            {
                context.Result = new RedirectToActionResult("Login", "EventHub", null);
            }
        }
    }
}
