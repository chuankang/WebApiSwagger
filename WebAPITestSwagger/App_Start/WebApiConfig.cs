using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Swashbuckle.Application;

namespace WebAPITestSwagger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region 允许全局跨域

            var cors = new EnableCorsAttribute("*", "*", "*");
            cors.PreflightMaxAge = 100000;
            //跨域
            config.EnableCors(cors);

            #endregion

            // Web API 配置和服务
            // Web API 路由
            config.MapHttpAttributeRoutes();

            //设置默认的为Swagger
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
