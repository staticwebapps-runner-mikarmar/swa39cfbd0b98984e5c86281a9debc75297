using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace StaticWebAppsEndToEndTesting.GetMessage
{
    public class GetMessage
    {
        [Function("GetMessage")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            string message = File.ReadAllText(Path.Join(Environment.CurrentDirectory, "content.txt"));
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(message);
            return response;
        }
    }
}
