using ClientLibrary.Services.Contracts;

public class LocaleService : ILocaleService
{
    private readonly HttpClient _httpClient;

    public LocaleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetStringAsync(string key, int languageId)
    {
        var response = await _httpClient.GetAsync($"api/localization/{key}/{languageId}");
        if (response.IsSuccessStatusCode)
        {
            var contentType = response.Content.Headers.ContentType?.MediaType;
            if (contentType == "application/json")
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Log or handle unexpected content type
                return $"Unexpected content type: {contentType}";
            }
        }
        return key;
    }
}
