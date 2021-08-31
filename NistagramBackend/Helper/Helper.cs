using System;
using System.Net.Http;

namespace NistagramBackend.Helper
{
    public class ApiGateway
    {

        public HttpClient InitialOffline()
        {
            string link = "http://localhost:48837/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(link);
            return client;
        }

        public HttpClient InitialOnline()
        {
            string link = "http://localhost:6709";
            var client = new HttpClient();
            client.BaseAddress = new Uri(link);
            return client;
        }
    }
}
