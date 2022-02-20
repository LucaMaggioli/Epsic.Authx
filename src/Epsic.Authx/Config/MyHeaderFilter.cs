using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Net.Http;

namespace Epsic.Authx.Config
{
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (string.Equals(context.ApiDescription.HttpMethod, HttpMethod.Get.Method, StringComparison.InvariantCultureIgnoreCase))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Required = false,
                    Example = new OpenApiString("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJJZCI6ImJhNWZhNjYxLWQwYWQtNDQ0Ny1iNTYwLTI5ZWJkMzU3NmU3NiIsInN1YiI6Imx1Y2FAbWFpbC5jb20iLCJlbWFpbCI6Imx1Y2FAbWFpbC5jb20iLCJuYmYiOjE2NDUzNjk2NDcsImV4cCI6MTY0NTM5MTI0NywiaWF0IjoxNjQ1MzY5NjQ3fQ.tn1tut-jFgCaqNvGLxCKlGDnCldhCJH68e_ajjnIT6T56jO1AA3hcqrHBnUXJXGeOjbWgYcGNSE4MJypFUPLZQ")
                });
            }
        }
    }
}
