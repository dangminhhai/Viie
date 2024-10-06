using BaseLibrary.DTOs;
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

        public async Task<string> GetStringAsync(string key, int languageId)
        {
            var resource = await _context.LocaleStringResources
                .FirstOrDefaultAsync(r => r.Key == key && r.LanguageId == languageId);

            return resource?.Value ?? key;
        }
    }
}
