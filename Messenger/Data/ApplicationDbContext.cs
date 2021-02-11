using IdentityServer4.EntityFramework.Options;
using Messenger.Data.Entities;
using Messenger.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Messenger.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employes { get; set; }
        public DbSet<FullName> FullNames { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<WorkingPlace> WorkingPlaces { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FullName>().HasData(new[] {
                new FullName()
                    {
                        Id = 1,
                        FirstName = "Alexandr",
                        LastName = "Digilevich",
                        MiddleName = "Grigorievich"
                    }
            });

            modelBuilder.Entity<WorkingPlace>().HasData(new[] {
                new WorkingPlace()
                    {
                        Id = 1,
                        CompanyName = "Microsoft Company",
                        Address = "Minsk, Smolyachkova 16"
                    }
            });

            modelBuilder.Entity<Employee>().HasData(new[] {new Employee
                {
                    Id = 1,
                    FullNameId = 1,
                    Position = "Developer",
                    WorkingPlaceId = 1
                }});

            base.OnModelCreating(modelBuilder);
        }
    }
}
