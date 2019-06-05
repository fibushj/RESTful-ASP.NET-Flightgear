using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ex3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Display", "display/{param1}/{param2}",
            defaults: new { controller = "Display", action = "Decide" });

            routes.MapRoute("Display2", "display/{ip}/{port}/{interval}",
            defaults: new { controller = "Display", action = "MultiplePoints" });

            routes.MapRoute("Save", "save/{ip}/{port}/{interval}/{duration}/{filename}",
            defaults: new { controller = "Display", action = "Save" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Display", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
