using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace App.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null, "",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
                );


            routes.MapRoute(
                name: "AllProducts-page",
                url: "Page{page}",
                defaults: new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                }
                );

            routes.MapRoute
                (
                    "Catepory/Page2",
                    "{catergory}/Page{page}",
                    new
                    {
                        controller = "Product",
                        action = "List"
                    },
                    new { page = @"\d+" }
                );

            routes.MapRoute
                (
                "Category/",
                "{category}",
                new
                {
                    controller = "Product",
                    action = "List",
                    page = 1
                }
                );

            routes.MapRoute("default", "{controller}/{action}");
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new
            //    {
            //        controller = "Product",
            //        action = "List",
            //        id = UrlParameter.Optional
            //    }
            //);


        }
    }
}
