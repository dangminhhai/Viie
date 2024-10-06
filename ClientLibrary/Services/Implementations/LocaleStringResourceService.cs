using ClientLibrary.Services.Contracts;

namespace ClientLibrary.Services.Implementations
{
    public class LocaleStringResourceService : ILocaleStringResourceService
    {
        private readonly HttpClient _httpClient;

        public LocaleStringResourceService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SystemApiClient");
        }

        public async Task<string> GetStringAsync(string key, int languageId)
        {
            var response = await _httpClient.GetAsync($"api/localization/{key}/{languageId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return key;
        }
    }
}
