using System;
using System.Net.Http;

namespace NistagramBackend.Helper
{
    public class ApiGateway
    {

        public HttpClient InitialOffline()
        {
            string uri = "http://localhost:48837/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            return client;
        }

        public HttpClient InitialOnline()
        {
            string uri = "http://localhost:6709";
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            return client;
        }

        public HttpClient InitialChat()
        {
            string uri = "http://localhost:56846";
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            return client;
        }
    }
}
