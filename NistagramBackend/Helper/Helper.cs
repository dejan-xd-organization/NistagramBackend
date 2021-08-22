using System;
using System.Net.Http;

namespace NistagramBackend.Helper
{
    public class OfflineApi
    {
        public HttpClient Initial()
        {
            string uri = "http://localhost:5001/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            return client;
        }
    }
}
