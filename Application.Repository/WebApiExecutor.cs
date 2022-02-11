﻿using System;
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

        public WebApiExecutor(IHttpClientFactory httpClientFactory)
        {
            _baseUrl = "http://localhost:5000/api"; // #sob: move this to config file and provide it to the default exising confi
            _httpClient = httpClientFactory.CreateClient();

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
