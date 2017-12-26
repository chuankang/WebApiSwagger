using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;

namespace WebAPITestSwagger.Filter
{
    ///　<summary>
    ///　权限拦截
    ///　</summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {


        public AuthorizeFilterAttribute()
        {
            AllowAll = false;
        }

        /// <summary>
        /// 是否允许所有人查看
        /// </summary>
        public bool AllowAll { get; set; }


        /// <summary>
        /// Token认证 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (AllowAll) { return; }


            string json = string.Empty;
            var request = filterContext.Request;
            if (request.Headers.Contains("token"))
            {
                json = request.Headers.GetValues("token").SingleOrDefault();
            }

            if (string.IsNullOrEmpty(json))
            {
                Forbidden(filterContext);
                return;
            }

            //验证权限

            if (!json.Equals("yuzd"))
            {
                Forbidden(filterContext);
                return;
            }
        }


        private void Forbidden(HttpActionContext filterContext)
        {
            var content = JsonConvert.SerializeObject(new { Status = HttpStatusCode.Unauthorized, Info = "未授权" });
            filterContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.Unauthorized
            };
        }

        
    }

    public class filterContextInfo
    {
        public filterContextInfo(System.Web.Http.Controllers.HttpActionContext filterContext)
        {

            #region 获取链接中的字符

            //获取 controllerName 名称
            controllerName = filterContext.ControllerContext.ControllerDescriptor.ControllerName;

            //获取ACTION 名称
            actionName = filterContext.ActionDescriptor.ActionName;

            #endregion 获取链接中的字符
        }



        /// <summary>
        /// 获取 controllerName 名称
        /// </summary>
        public string controllerName { get; set; }

        /// <summary>
        /// 获取ACTION 名称
        /// </summary>
        public string actionName { get; set; }
    }
}