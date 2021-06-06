using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.DataContracts
{
    public class SignInResponse
    {
        public bool IsSuccessful { get; set; }

        public string AuthorizationToken { get; set; }

        public DateTime ValidTill { get; set; }
    }
}