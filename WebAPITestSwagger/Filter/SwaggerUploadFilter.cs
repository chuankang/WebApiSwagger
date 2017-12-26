using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace WebAPITestSwagger.Filter
{
    public class SwaggerUploadFilter : IOperationFilter
    {

        /// <summary>
        ///     文件上传
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (!string.IsNullOrWhiteSpace(operation.summary) && operation.summary.Contains("upload"))
            {
                operation.consumes.Add("application/form-data");
                operation.parameters.Add(new Parameter
                {
                    name = "file",
                    @in = "formData",
                    description = "文件",
                    required = true,
                    type = "file"
                });
            }
        }
    }
}