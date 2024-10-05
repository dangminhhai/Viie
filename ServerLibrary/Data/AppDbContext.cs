
using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<LocaleStringResource> LocaleStringResources { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //General Departments / Department / JobPosition
        public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }

        // Country / City/ Town
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }

        // Authentication / Role / System Roles
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }


        //Other / Vacation / Sanction / Doctor / Overtime
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }

        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }

        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<SanctionType> SanctionTypes { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specify schemas for tables
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers", "Auth");
            modelBuilder.Entity<SystemRole>().ToTable("SystemRoles", "Auth");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles", "Auth");
            modelBuilder.Entity<RefreshTokenInfo>().ToTable("RefreshTokenInfos", "Auth");

            modelBuilder.Entity<Overtime>().ToTable("Overtimes", "Personnel");
            modelBuilder.Entity<OvertimeType>().ToTable("OvertimeTypes", "Personnel");

            // Add other entities with schemas as needed
            modelBuilder.Entity<Employee>().ToTable("Employees", "Personnel");
            //modelBuilder.Entity<Location>().ToTable("Locations", "Personnel");
            //modelBuilder.Entity<BusinessUnit>().ToTable("BusinessUnits", "Personnel");
            modelBuilder.Entity<Department>().ToTable("Departments", "Personnel");
            modelBuilder.Entity<JobPosition>().ToTable("JobPositions", "Personnel");
            modelBuilder.Entity<Country>().ToTable("Countries", "Personnel");
            modelBuilder.Entity<City>().ToTable("Cities", "Personnel");
            modelBuilder.Entity<Town>().ToTable("Towns", "Personnel");
            modelBuilder.Entity<Vacation>().ToTable("Vacations", "Personnel");
            modelBuilder.Entity<VacationType>().ToTable("VacationTypes", "Personnel");
            modelBuilder.Entity<Sanction>().ToTable("Sanctions", "Personnel");
            modelBuilder.Entity<SanctionType>().ToTable("SanctionTypes", "Personnel");
            modelBuilder.Entity<Doctor>().ToTable("Doctors", "Personnel");
        }
    }
}
