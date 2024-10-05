using BaseLibrary.DTOs;

namespace ServerLibrary.Repositories.Contracts
{
    public interface ILocaleStringResourceRepository
    {
        LocaleStringResourceDto GetResource(string key, int languageId);
    }

}
