using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class LocationRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Location>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDbContext.Locations.FindAsync(id);
            if (dep is null) return NotFound();

            appDbContext.Locations.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Location>> GetAll() => await appDbContext.Locations.ToListAsync();
        public async Task<Location> GetById(int id) => await appDbContext.Locations.FindAsync(id);

        public async Task<GeneralResponse> Insert(Location item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
                return new GeneralResponse(false, "Location already added");
            appDbContext.Locations.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Location item)
        {
            var dep = await appDbContext.Locations.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Location not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Locations.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
