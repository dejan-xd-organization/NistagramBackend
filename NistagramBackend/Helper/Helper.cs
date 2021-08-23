using System;
using System.Configuration;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace NistagramBackend.Helper
{
    public class OfflineApi
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
    }
}
