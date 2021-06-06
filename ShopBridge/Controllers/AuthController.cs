using ShopBridge.DataContracts;
using ShopBridge.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{

    public class AuthController : ApiController
    {
        [HttpPost, Route("api/Auth/Register")]
        public async Task<HttpResponseMessage> Register(RegisterRequest request)
        {
            try
            {
                var response = await AuthHelper.RegisterInternal(request);
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }

        [HttpPost, Route("api/Auth/SignIn")]
        public async Task<HttpResponseMessage> SignIn(SignInRequest request)
        {
            try
            {
                var response = await AuthHelper.SignInInternal(request);
                return ResponseGenerator.GetSuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ResponseGenerator.GetFailureResponse(ex.Message, ex.StackTrace);
            }
        }


    }
}
