using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class DepartmentRepository : IGenericRepositoryInterface<Department>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserAccount _userAccount;

        public DepartmentRepository(AppDbContext appDbContext, IUserAccount userAccount)
        {
            _appDbContext = appDbContext;
            _userAccount = userAccount;
        }

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await _appDbContext.Departments.FindAsync(id);
            if (dep is null) return NotFound();

            dep.IsDeleted = true;
            dep.UpdatedOnUtc = DateTime.UtcNow;
            dep.UpdatedBy = await _userAccount.GetCurrentUserId();
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await _appDbContext
            .Departments.AsNoTracking()
            .Include(bu => bu.BusinessUnit)
            .ToListAsync();

        public async Task<Department> GetById(int id) => await _appDbContext.Departments.FindAsync(id);

        public async Task<GeneralResponse> Insert(Department item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            item.CreatedOnUtc = DateTime.UtcNow;
            item.CreatedBy = await _userAccount.GetCurrentUserId();
            item.IsDeleted = false;

            _appDbContext.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var dep = await _appDbContext.Departments.FindAsync(item.Id);
            if (dep is null) return NotFound();

            dep.Name = item.Name;
            dep.BusinessUnitId = item.BusinessUnitId;
            dep.UpdatedOnUtc = DateTime.UtcNow;
            dep.UpdatedBy = await _userAccount.GetCurrentUserId();
            await Commit();
            return Success();
        }

        private async Task Commit() => await _appDbContext.SaveChangesAsync();

        private static GeneralResponse NotFound() => new(false, "Sorry department not found");

        private static GeneralResponse Success() => new(true, "Process completed");

        private async Task<bool> CheckName(string name)
        {
            var item = await _appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
