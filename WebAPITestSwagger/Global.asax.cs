using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;

namespace WebAPITestSwagger
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //修正 ASP.NET Web API 的 XmlFormatter 所支持的媒体类型(MediaType) , 目的是不默认输出XML数据，而输出Json.

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //设置序列化成JSON时，日期时间的格式
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    Culture = CultureInfo.GetCultureInfo("zh-CN"),
                    DateFormatString = "yyyy-MM-dd HH:mm:ss"
                };

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
