using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using TylerSupportPortal.Tests.Services;
using TylerSupportPortal.Tests.Models;
using System.Text.Json;


namespace TylerSupportPortal.Tests.Tests
{
    internal class ApiClientTests
    {
        [Test]
        public async Task GetAsync_ShouldReturnSuccessfulResponse()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            var apiClient = new ApiClient(httpClient);

            var apiPost = await apiClient.GetAsync<ApiPost>("posts/1");
        
            Assert.That(apiPost, Is.Not.Null);
            Assert.That(apiPost.UserId, Is.EqualTo(1));
            Assert.That(apiPost.Id, Is.EqualTo(1));
            Assert.That(apiPost.Title, Is.Not.Empty);
            Assert.That(apiPost.Body, Is.Not.Empty);

        }
    }
}
