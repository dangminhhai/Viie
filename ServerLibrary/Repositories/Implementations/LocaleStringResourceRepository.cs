using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
namespace ServerLibrary.Repositories.Implementations
{
    public class LocaleStringResourceRepository : ILocaleStringResourceRepository
    {
        private readonly AppDbContext _context;

        public LocaleStringResourceRepository(AppDbContext context)
        {
            _context = context;
        }

        public LocaleStringResourceDto GetResource(string key, int languageId)
        {
            var resource = _context.LocaleStringResources
                .FirstOrDefault(r => r.ResourceKey == key && r.LanguageId == languageId);
            if (resource == null) return null;

            return new LocaleStringResourceDto
            {
                Id = resource.Id,
                ResourceKey = resource.ResourceKey,
                ResourceValue = resource.ResourceValue,
                LanguageId = resource.LanguageId
            };
        }
    }

}
