using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class WebApiExecutor : IWebApiExecutor
    {
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly IConfiguration _configuration;

        public WebApiExecutor(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("WebApiClient:WebApiBaseUrl");

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<T> InvokeGetAsync<T>(string uri)
        {
            return await _httpClient.GetFromJsonAsync<T>(GetUrl(uri), _jsonSerializerOptions);
        }

        private string GetUrl(string uri)
        {
            return $"{_baseUrl}/{uri}";
        }
    }
}
