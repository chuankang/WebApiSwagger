using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Models;
using WebAPITestSwagger.Filter;

namespace WebAPITestSwagger.Controllers
{
    /// <summary>
    /// 测试接口
    /// </summary>
    public class TestController : ApiController
    {
        /// <summary>
        /// [upload] 上传资源
        /// </summary>
        /// <author>联调中</author>
        /// <returns></returns>
        [HttpPost, Route("UploadResource")]
        [AuthorizeFilter]
        public ResultJsonInfo<string> UploadResource()
        {
            var result = new ResultJsonInfo<string>();
            var file = HttpContext.Current.Request.Files[0];
            result.Info = "fail";
            result.Status = ResultConfig.Fail;
            return result;
        }

        /// <summary>
        /// 获取person列表
        /// </summary>
        /// <author>联调中</author>
        /// <returns></returns>
        [HttpGet, Route("GetPersonList")]
        [AuthorizeFilter]
        public ResultJsonInfo<List<Person>> GetPersonList()
        {
            var result = new ResultJsonInfo<List<Person>>();
            result.Data = new List<Person> {new Person {Name = "yuzd",Age = 25} };
            result.Status = ResultConfig.Success;
            result.Info = "ok";
            return result;
        }
    }
}
