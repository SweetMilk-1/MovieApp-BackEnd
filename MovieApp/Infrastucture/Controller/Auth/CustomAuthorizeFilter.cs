using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieApp.Models.Common;
using System.Net;

namespace MovieApp.Infrastucture.Controller.Auth
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly bool _isAdmin;
        
        

        public CustomAuthorizationFilterAttribute(bool isAdmin = false)
        {
            _isAdmin = isAdmin;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userData = context.HttpContext.User?.GetUserDataFromJwt();
            if (userData == null)
            {
                NotAuthorized(context);
                return;
            }

            if (_isAdmin && !userData.IsAdmin)
            {
                Forbidden(context);
                return;
            }
        }


        private static void Forbidden(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Result = new JsonResult(new ErrorDto { Message = "Недостаточно прав доступа" });
            return;
        }

        private static void NotAuthorized(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new JsonResult(new ErrorDto { Message = "Необходима авторизация" });
            return;
        }
    }
}

