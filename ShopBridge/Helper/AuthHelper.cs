using ShopBridge.DataContracts;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;

namespace ShopBridge
{
    public static class AuthHelper
    {
        public async static Task<SignInResponse> SignInInternal(SignInRequest request)
        {
            var isAuthenticated = IsAuthenticated(request.Username, request.Password);
            if (!isAuthenticated)
                return new SignInResponse() { IsSuccessful = false };

            var authorizationToken = Guid.NewGuid().ToString();
            var validTill = DateTime.Now.AddDays(1);
            return new SignInResponse() { IsSuccessful = true, AuthorizationToken = authorizationToken, ValidTill = validTill };
        }

        public async static Task<object> RegisterInternal(RegisterRequest request)
        {
            var context = new ApplicationContext();
            if (context.Users.Where(u => u.Email == request.Email).Count() > 0)
                throw new Exception("User already exists with the specified email");
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                throw new Exception("Please provide required details");

            context.Users.Add(new User() { Email = request.Email, FirstName = request.FirstName, LastName = request.LastName, Mobile = request.Mobile });
            if (context.SaveChanges() > 0)
            {
                context.UserCredentials.Add(new UserCredentials(context.Users.Where(u => u.Email == request.Email).FirstOrDefault(), GetEncodedSecret(request.Password)));
                return context.SaveChanges();
            }

            return new { Message = "You are registered" };
        }

        private static bool IsAuthenticated(string username, string password)
        {
            return username.Equals("pratikj.atwork@gmail.com") && password.Equals("123");
        }

        private static string GetEncodedSecret(string secret)
        {
            byte[] encData_byte = new byte[secret.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(secret);
            return Convert.ToBase64String(encData_byte);
        }
    }
}