using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

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

        public async Task<T?> GetAsync<T>(string endpoint)
    where T : class
        {
            using var response = await _httpClient.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
