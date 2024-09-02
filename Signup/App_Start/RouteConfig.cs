using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Signup
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            routes.MapRoute(
                name: "GetUser",
                url: "Signup/GetUser/{id}",
                defaults: new { controller = "Signup", action = "GetUser", id = UrlParameter.Optional }
            );

           
            routes.MapRoute(
                name: "UpdateUser",
                url: "Signup/UpdateUser/{id}",
                defaults: new { controller = "Signup", action = "UpdateUser", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteUser",
                url: "Signup/DeleteUser/{id}",
                defaults: new { controller = "Signup", action = "DeleteUser", id = UrlParameter.Optional }
            );
           
          
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Signup", action = "AddUser", id = UrlParameter.Optional }
            );
        }
    }
}
