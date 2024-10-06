using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
namespace ServerLibrary.Repositories.Implementations
{
    public class BusinessUnitRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<BusinessUnit>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var bu = await appDbContext.BusinessUnits.FindAsync(id);
            if (bu is null) return NotFound();

            appDbContext.BusinessUnits.Remove(bu);
            await Commit();
            return Success();
        }

        public async Task<List<BusinessUnit>> GetAll() => await appDbContext
            .BusinessUnits.AsNoTracking()
            .Include(l => l.Location)
            .ToListAsync();
        public async Task<BusinessUnit> GetById(int id) => await appDbContext.BusinessUnits.FindAsync(id);

        public async Task<GeneralResponse> Insert(BusinessUnit item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Business Unit already added");
            appDbContext.BusinessUnits.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(BusinessUnit item)
        {
            var bu = await appDbContext.BusinessUnits.FindAsync(item.Id);
            if (bu is null) return NotFound();
            bu.Name = item.Name;
            bu.LocationId = item.LocationId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry BusinessUnit not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.BusinessUnits.FirstOrDefaultAsync(bu => bu.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }


    }
}
