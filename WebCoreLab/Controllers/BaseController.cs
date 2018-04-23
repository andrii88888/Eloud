using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreLab.Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using WebCoreLab.Data;

namespace WebCoreLab.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext context { get; set; }

        protected BaseController(ApplicationDbContext _context)
        {
            context = _context;
        }
    }

    public class RedirectFilter : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (!IsAuthorized(filterContext))
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home" }));
        //    }
        //}

        //private bool IsAuthorized(ActionExecutingContext filterContext)
        //{
        //    bool result = false;

        //    User user = filterContext.HttpContext.Session.Get<User>("_CurUser");

        //    result = user != null;

        //    return true;
        //}
    }

    public class RedirectFilterNotAdmin : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (!IsAdmin(filterContext))
        //    {
        //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home" }));
        //    }
        //}

        //private bool IsAdmin(ActionExecutingContext filterContext)
        //{
        //    bool result = false;

        //    User user = filterContext.HttpContext.Session.Get<User>("_CurUser");

        //    result = user != null && user.Role.Code == "ADMIN";

        //    return result;
        //}
    }
}