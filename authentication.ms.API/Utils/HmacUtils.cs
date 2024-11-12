using System;
using System.Security.Cryptography;
using System.Text;

namespace authentication.ms.API.Utils
{
    public class HmacUtils
    {
        public string GenerateHMAC(string content)
        {
            try
            {
                string secretKey = Environment.GetEnvironmentVariable("HMAC_SECRET_KEY") ?? "695035ae-1a6e-4d9d-ad35-b54d6048dcf6";
                string data = content.Replace(" ", ""); // just body of request , can be more complex.

                // if no using , then would have to do try finally , with Dispose();
                using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
                byte[] rawHmac = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return Convert.ToBase64String(rawHmac);
            }
            catch (Exception e)
            {
                throw new Exception("Error generating HMAC: " + e.Message);
            }
        }
    }
}
