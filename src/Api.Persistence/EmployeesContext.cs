using System;
using Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.EmployeeId);
                e.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
                e.HasOne<Address>(a => a.Address)
                    .WithOne(p => p.Employee);
            });

            modelBuilder.Entity<Address>(e =>
            {
                e.HasKey(e => e.AddressId);
                e.Property(e => e.AddressId).ValueGeneratedOnAdd();
                e.HasOne<Employee>(a => a.Employee)
                    .WithOne(p => p.Address);
            });

            modelBuilder.Entity<Address>().HasData(new Address
            {
                AddressId = 1,
                UnitNumber = "1",
                StreetNumber = "1",
                StreetName = "High Street",
                Suburb = "St Kilda",
                City = "San Fransisco",
                Postcode = 3004,
                Active = true,
                CreatedBy = "admin",
                CreatedOn = DateTime.UtcNow
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                AddressId = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 20,
                Active = true,
                CreatedBy = "admin",
                CreatedOn = DateTime.UtcNow
            });
        }
    }
}
