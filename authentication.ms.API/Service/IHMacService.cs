namespace authentication.ms.API.Service
{
    public interface IHMacService
    {
        bool validateAndProcessRequest(string content , string signature);
    }
}
