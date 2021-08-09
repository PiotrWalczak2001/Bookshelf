using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookshelf.App.Services
{
    public class GetTestDataService : IGetTestDataService
    {
        private readonly HttpClient _httpClient;
        public GetTestDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetData()
        {
            return await _httpClient.GetStringAsync($"book/test");
            //return await JsonSerializer.DeserializeAsync<PassedDataDto>(await _httpClient.GetStreamAsync($"book/test"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
