using BaseLibrary.DTOs;

namespace ServerLibrary.Repositories.Contracts
{
    public interface ILocaleStringResourceRepository
    {
        Task<string> GetStringAsync(string key, int languageId);
    }
}
