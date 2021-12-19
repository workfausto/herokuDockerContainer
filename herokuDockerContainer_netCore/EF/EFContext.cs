using herokuDockerContainer_netCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herokuDockerContainer_netCore.EF
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=localhost;port=3306;database=EFCoreMySQL;user=root;password=123456", new MySqlServerVersion(new Version(8, 0, 11)));
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configuring the one to many relationship

            modelBuilder.Entity<EmployeeAddress>()
                    .HasKey(e => e.EmployeeID);

            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees);
        }
    }
}
