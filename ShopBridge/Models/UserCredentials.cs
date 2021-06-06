using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class UserCredentials : DocumentClass
    {
        public UserCredentials(User user, string encryptedSecret)
        {
            this.UserId = user.Id;
            this.Secret = encryptedSecret;
            ValidTill = DateTime.Now.AddDays(90);
        }

        public Guid UserId { get; private set; }

        public string Secret { get; private set; }

        public DateTime ValidTill { get; private set; }
    }
}