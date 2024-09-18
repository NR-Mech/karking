using Microsoft.AspNetCore.Mvc.Filters;

namespace Karking.Back.Filters;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter)) { }
}

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private const string ApiKeyHeaderName = "X-API-Key";
    private const string ApiKeyValue = "e46b113c7c914c9b8d3da8d91ac8e6f2";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];

        if (apiKey != ApiKeyValue)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
