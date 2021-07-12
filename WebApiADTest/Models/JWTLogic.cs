using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;

namespace WebApiADTest.Models
{
    public class JWTLogic
    {
        private static string secret = "maxpower";

        public static string GetToken(string name)
        {
            var expired = DateTimeOffset.Now.AddHours(1).ToUnixTimeSeconds(); //過期時間
            var notBefore = DateTimeOffset.Now.ToUnixTimeSeconds();             //在此時間前 token為無效
            var issuedAt = DateTimeOffset.Now.ToUnixTimeSeconds();              //建立時間
            var JToken = new JwtBuilder().
                    WithAlgorithm(new HMACSHA256Algorithm()).
                    WithSecret(secret).
                    AddClaim("iat", issuedAt).
                    AddClaim("exp", expired).
                    AddClaim("nbf", notBefore).
                    AddClaim("name", name).
                    Build();
            return JToken;
        }

        public static IDictionary<string, string> DeToken(string token)
        {
            var dict = new JwtBuilder().
              WithSecret(secret).
              MustVerifySignature().
              Decode<IDictionary<string, string>>(token);
            return dict;
        }
    }
}