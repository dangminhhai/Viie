namespace ClientLibrary.Services.Contracts
{
    public interface ILocaleStringResourceService
    {
        Task<string> GetStringAsync(string key, int languageId);
    }
}
