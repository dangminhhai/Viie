using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
namespace ServerLibrary.Repositories.Implementations
{
    public class JobPositionRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<JobPosition>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var position = await appDbContext.JobPositions.FindAsync(id);
            if (position is null) return NotFound();

            appDbContext.JobPositions.Remove(position);
            await Commit();
            return Success();
        }

        public async Task<List<JobPosition>> GetAll() => await appDbContext
            .JobPositions.
            AsNoTracking().
            Include(d => d.Department)
            .ToListAsync();
        public async Task<JobPosition> GetById(int id) => await appDbContext.JobPositions.FindAsync(id);
        public async Task<GeneralResponse> Insert(JobPosition item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
            appDbContext.JobPositions.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(JobPosition item)
        {
            var position = await appDbContext.JobPositions.FindAsync(item.Id);
            if (position is null) return NotFound();
            position.Name = item.Name;
            position.DepartmentId = item.DepartmentId;
            await Commit();
            return Success();
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "Sorry department not found");
        private static GeneralResponse Success() => new(true, "Process completed");
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.JobPositions.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
