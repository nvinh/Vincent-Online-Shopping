using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
              new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "Product Category",
                url: "Product/{metatitle}-{proCateid}",
                defaults: new { controller = "Product", action = "ProCategory", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "ProductDetail/{metatitle}-{proId}",
                defaults: new { controller = "Product", action = "ProDetail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "News",
                url: "News",
                defaults: new { controller = "NewsContent", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "News Detail",
                url: "NewsDetail/{metatitle}-{id}",
                defaults: new { controller = "NewsContent", action = "NewsDetail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Tags",
                url: "Tag/{tagId}",
                defaults: new { controller = "NewsContent", action = "Tag", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
               name: "Login",
               url: "Login",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop3.Controllers" }
           );

            routes.MapRoute(
               name: "Search",
               url: "Search",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop3.Controllers" }
           );

            routes.MapRoute(
                name: "Cart",
                url: "Cart",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Add to Cart",
                url: "addtocart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "Payment",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "Success payment",
                url: "Success",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            routes.MapRoute(
                name: "PaymentError",
                url: "PaymentError",
                defaults: new { controller = "Cart", action = "PaymentError", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop3.Controllers" }
            );

            // phan default nay luon phai dat o duoi cung cua file RouteConfig
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new[] { "OnlineShop3.Controllers" }
            );
        }
    }
}
