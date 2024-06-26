using GestorDeTurnos.Application.Extensions;
using GestorDeTurnos.Domain.Common;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GestorDeTurnos.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _userName;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _userName = httpContextAccessor.HttpContext.GetUserName();
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<EstablishmentTypes> EstablishmentTypes { get; set; }
        public DbSet<EstablishmentRoles> EstablishmentRoles { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Employees> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new EstablishmentConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new EstablishmentTypesConfiguration());
            modelBuilder.ApplyConfiguration(new EstablishmentRolesConfiguration());
            modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _userName;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _userName;
                        entry.Entity.LastModified = DateTime.Now;
                        break;

                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}