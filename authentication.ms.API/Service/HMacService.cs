using authentication.ms.API.Utils;

namespace authentication.ms.API.Service
{
    public class HMacService : IHMacService
    {
        private readonly HmacUtils hmacUtils;

        public HMacService(HmacUtils hmacUtils)
        {
            this.hmacUtils = hmacUtils;
        }
        public bool validateAndProcessRequest(string content, string signature)
        {
            string serverHmacSignature = hmacUtils.GenerateHMAC(content);
            if (serverHmacSignature.Equals(signature))
            {
                return true;
            }
            return false;
        }
    }
}
