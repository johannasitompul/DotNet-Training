using EmpDepModelsLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EmpDepDALEFLibrary
{
    class EmpDepContext : DbContext
    {
        public EmpDepContext() : base("conn")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasRequired<Department>(d => d.Department)
                .WithMany(e => e.Employees)
                .HasForeignKey<int>(d => d.Department_Id);
        }
    }
}
