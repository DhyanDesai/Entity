using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Entity
{
    class DemoDbContext:DbContext
    {
        public DbSet<EmployeeModel> EmployeeModel{get;set;}
        public DbSet<DepartmentModel> DepartmentModel{get;set;} 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=CS60-PC;Initial catalog=EntityDB;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<DepartmentModel>().ToTable("DepartmentModel","dbo").HasKey(x=>x.ID);

            modelBuilder.Entity<EmployeeModel>().ToTable("EmployeeModel","dbo").HasKey(x=>x.ID);

            modelBuilder.Entity<DepartmentModel>().HasMany<EmployeeModel>(x=>x.EmployeeModel).WithOne(x=>x.DepartmentModel).HasForeignKey(x=>x.Dept_ID);

        }
        
    }
}