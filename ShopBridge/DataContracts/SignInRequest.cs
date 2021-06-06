using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ShopBridge.DataContracts
{
    
    public class SignInRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}