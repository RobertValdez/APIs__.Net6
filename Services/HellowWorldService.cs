using System.Net.Http.Headers;
namespace APIs_con_.NET.Services
{
    public class HellowWorldService : IHelloWorldService
    {
        public string GetHellowWorld()
        {
            return "Hola Mundo";
        }
    }
}

public interface IHelloWorldService
{
    string GetHellowWorld();
}