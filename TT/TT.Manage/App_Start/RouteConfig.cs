using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TT.Manage
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            RouteTable.Routes.MapRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { action = "DefaultAction", id = System.Web.Http.RouteParameter.Optional }
            );
        }
    }
}