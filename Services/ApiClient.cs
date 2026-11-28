using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace TylerSupportPortal.Tests.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public HttpClient HttpClient => _httpClient;

        public async Task<HttpResponseMessage> GetAsync(string endpoint)
        {
            return await _httpClient.GetAsync(endpoint);
        }
    }
}
