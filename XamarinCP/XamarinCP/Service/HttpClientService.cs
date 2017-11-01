using System;
using System.Net.Http;

namespace XamarinCP.Service
{
    public class HttpClientService
    {
        private static HttpClient _client;

        public HttpClientService()
        {
            if (_client == null)
                _client = new HttpClient { MaxResponseContentBufferSize = 256000, Timeout = new TimeSpan(0, 0, 0, 10) };
        }

        public static HttpClient Instance {
            get
            {
                return _client ?? new HttpClient { MaxResponseContentBufferSize = 256000, Timeout = new TimeSpan(0, 0, 0, 10) };
            }
        }
    }
}