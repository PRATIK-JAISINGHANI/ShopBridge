using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace ShopBridge.Helper
{
    public static class ResponseGenerator
    {
        public static HttpResponseMessage GetSuccessResponse(object response)
        {
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(response), System.Text.Encoding.UTF8, "application/json") };
        }

        public static HttpResponseMessage GetFailureResponse(string errorMessage, string errorStack)
        {
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Error = errorMessage }), System.Text.Encoding.UTF8, "application/json") };
        }
    }
}