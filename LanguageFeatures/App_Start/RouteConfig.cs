using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LanguageFeatures {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = true;

            //routes.MapRoute(
            //    name: "Defalut2",
            //    url: "Test.html",
            //    defaults: new { controller = "Home",action = "IndexRouteData" }
            //    );


            //基本路由//访问地址http://localhost:5328/Home/Index/0
            routes.MapRoute(
                name: "Defalut",
                url: "{controller}/{action}/{id}/{*name}",
                // 提示：default中的默认值变量的名称必须和url中的名称相同，但是大小写不限制。
                defaults: new { controller = "Home",action = "IndexRouteData",id = "1",name = UrlParameter.Optional },
                //路由约束,未约束之前此网址可以访问 http://localhost:5328/Home/IndexRouteData/A/nihao
                //通过 httpMethod = new HttpMethodConstraint("GET","POST")可以约束该路由只能通过那种方式访问。
                constraints: new { id = @"^\d*$" }
                //constraints: new {}
                   );



            //静态URL片段
            routes.MapRoute(
                name: "d1",
                url: "X{controller}/{action}",
                defaults: new {controller="Home",action="Index"}
                );


            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }

    }

    public class MyRouteConstraint:IRouteConstraint {

        //public bool Match(HttpContextBase httpContext,Route route,string parameterName,RouteValueDictionary values,RouteDirection routeDirection) {
        //    return httpContext.Request.UserAgent.Contains("Chrome");
        //}
        public bool Match(HttpContextBase httpContext,Route route,string parameterName,RouteValueDictionary values,RouteDirection routeDirection) {
            return httpContext.Request.UserAgent.Contains("Chrome");
        }
    }
}
