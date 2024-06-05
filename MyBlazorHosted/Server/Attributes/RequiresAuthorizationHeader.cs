using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MyBlazorHosted.Server.Attributes
{
    public class RequiresAuthorizationHeader : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = new UnauthorizedResult();

                return;
            }

            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();

            var apiKey = configuration.GetValue<string>("ApiKey");

            if (context.HttpContext.Request.Headers["Authorization"].ToString() != apiKey)
            {
                context.Result = new UnauthorizedResult();

                return;
            }
        }
    }
}
