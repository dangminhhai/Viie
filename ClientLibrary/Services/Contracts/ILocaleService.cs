namespace ClientLibrary.Services.Contracts
{
    public interface ILocaleService
    {
        Task<string> GetStringAsync(string key, int languageId);
    }
}
