using System;
using System.Net.Http;

namespace XamarinCP.Service
{
    public static class HttpClientService
    {
        public static HttpClient Client;
        public static HttpClient Instance => Client ?? new HttpClient { MaxResponseContentBufferSize = 256000, Timeout = new TimeSpan(0, 0, 0, 10) };
    }
}