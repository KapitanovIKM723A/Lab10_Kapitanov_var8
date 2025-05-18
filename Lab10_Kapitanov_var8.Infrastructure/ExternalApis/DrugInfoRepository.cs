using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Lab10_Kapitanov_var8.Infrastructure.ExternalApis
{
    public class DrugLabelResponse
    {
        public Result[] Results { get; set; } = null!;
    }

    public class Result
    {
        public string[] Indications_and_Usage { get; set; } = null!;
        public string[] Adverse_Reactions { get; set; } = null!;
        public string[] Purpose { get; set; } = null!;
    }

    public class DrugInfoRepository
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public DrugInfoRepository(HttpClient http, IConfiguration cfg)
        {
            _http = http;
            _baseUrl = cfg["OpenFda:BaseUrl"]!;
        }

        public async Task<DrugLabelResponse?> GetLabelByNameAsync(string name)
        {
            var encodedName = Uri.EscapeDataString($"openfda.brand_name:{name}");
            var url = $"{_baseUrl}?search={encodedName}&limit=1";

            var json = await _http.GetStringAsync(url);
            return JsonSerializer.Deserialize<DrugLabelResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
