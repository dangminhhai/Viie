using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System.Runtime.Intrinsics.Arm;

namespace ServerLibrary.Repositories.Implementations
{
    public class LocationRepository : IGenericRepositoryInterface<Location>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserAccount _userAccount;

        public LocationRepository(AppDbContext appDbContext, IUserAccount userAccount)
        {
            _appDbContext = appDbContext;
            _userAccount = userAccount;
        }
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var loc = await _appDbContext.Locations.FindAsync(id);
            if (loc is null) return NotFound();

            loc.IsDeleted = true;
            loc.UpdatedOnUtc = DateTime.UtcNow;
            loc.UpdatedBy = await _userAccount.GetCurrentUserId();
            await Commit();
            return Success();
        }

        public async Task<List<Location>> GetAll()
        {
            return await _appDbContext.Locations
                .Where(loc => !loc.IsDeleted)
                .ToListAsync();
        }
        public async Task<Location> GetById(int id)
        {
            var loc = await _appDbContext.Locations.FindAsync(id);
            if (loc == null || loc.IsDeleted)
            {
                return null; // Hoặc trả về một phản hồi phù hợp khác
            }
            return loc;
        }

        public async Task<GeneralResponse> Insert(Location item)
        {
            var checkIfNull = await CheckName(item.Name);
            if (!checkIfNull)
                return new GeneralResponse(false, "Location already added");
            item.CreatedOnUtc = DateTime.UtcNow;
            item.CreatedBy = await _userAccount.GetCurrentUserId(); // Implement this method to get the current user's ID
            item.IsDeleted = false;

            _appDbContext.Locations.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Location item)
        {
            var loc = await _appDbContext.Locations.FindAsync(item.Id);
            if (loc is null) return NotFound();
            loc.Name = item.Name;
            loc.UpdatedOnUtc = DateTime.UtcNow;
            loc.UpdatedBy = await _userAccount.GetCurrentUserId(); // Implement this method to get the current user's ID
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Sorry Location not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task Commit() => await _appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await _appDbContext.Locations
                .Where(loc => !loc.IsDeleted && loc.Name!.ToLower().Equals(name.ToLower()))
                .FirstOrDefaultAsync();
            return item is null;
        }
    }
}
