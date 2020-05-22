using KSAVideoConference.CommonBL;
using KSAVideoConference.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace KSAVideoConference.AppAdmin.Filters
{
    public class AuthorizeActionFilter : IActionFilter
    {
        private readonly AppUnitOfWork _UnitOfWork;

        private string _ControlerName;

        private readonly int _Fk_AccessLevel;

        public AuthorizeActionFilter(int Fk_AccessLevel, AppUnitOfWork UnitOfWork)
        {
            _Fk_AccessLevel = Fk_AccessLevel;
            _UnitOfWork = UnitOfWork;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _ControlerName = context.RouteData.Values["controller"].ToString();

            if (string.IsNullOrEmpty(AppMainData.Email))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            else if (!_UnitOfWork.SystemUserPermissionRepository.CheckAuthorization(_ControlerName, _Fk_AccessLevel))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = AppMainData.UnAuthorized }));
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(int Fk_AccessLevel)
            : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { Fk_AccessLevel };
        }
    }
}
