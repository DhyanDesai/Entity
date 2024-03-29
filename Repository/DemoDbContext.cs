using System.Net.NetworkInformation;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Entity
{
    class DemoDbContext : DbContext
    {
        public DbSet<EmployeeModel> EmployeeModel { get; set; }
        public DbSet<DepartmentModel> DepartmentModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-224OMT8 ;Initial catalog=EntityDB;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<DepartmentModel>().ToTable("DepartmentModel", "dbo").HasKey(x => x.ID);

            modelBuilder.Entity<EmployeeModel>().ToTable("EmployeeModel", "dbo").HasKey(x => x.ID);

            modelBuilder.Entity<DepartmentModel>().HasMany<EmployeeModel>(x => x.EmployeeModel).WithOne(x => x.DepartmentModel).HasForeignKey(x => x.Dept_ID);

        }
        public void ShowData()
        {
            int showInput = 0;
            System.Console.WriteLine("Press 1 to display from department table");
            System.Console.WriteLine("Press 2 to display from employee table");
            System.Console.WriteLine("Enter your choice:");
            showInput = Convert.ToInt32(Console.ReadLine());

            switch (showInput)
            {
                case 1:
                    foreach (var item in DepartmentModel)
                    {
                        System.Console.WriteLine($"ID : {item.ID}  , Name : {item.Dept_Name} ");
                    }
                    break;
                case 2:
                    foreach (var item in EmployeeModel)
                    {
                        System.Console.WriteLine($"ID : {item.ID} , FirstName : {item.First_Name} , LastName : {item.Last_name} , Department_ID : {item.Dept_ID} , Address : {item.Address} , City : {item.City} , State : {item.State}");
                    }
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid input!!!");
                    break;
            }

        }

        public void AddData()
        {
            int addInput = 0;
            System.Console.WriteLine("Press 1 to add from department table");
            System.Console.WriteLine("Press 2 to add from employee table");
            System.Console.WriteLine("Enter your choice:");
            addInput = Convert.ToInt32(Console.ReadLine());

            switch (addInput)
            {
                case 1:
                    System.Console.WriteLine("Enter Department values:");
                    System.Console.WriteLine("Enter Department Name");
                    string? Dname = Console.ReadLine();
                    var DepartmentModel = new DepartmentModel()
                    {
                        Dept_Name = Dname

                    };
                    Add(DepartmentModel);
                    SaveChanges();
                    SuccessMessage();
                    break;
                case 2:
                    System.Console.WriteLine("Enter Employee values:");
                        System.Console.WriteLine("Enter First Name");
                        string? Fname = Console.ReadLine();
                        System.Console.WriteLine("Enter Last Name");
                        string? Lname = Console.ReadLine();
                        System.Console.WriteLine("Enter Department ID");
                        int Did = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter Address");
                        string? add = Console.ReadLine();
                        System.Console.WriteLine("Enter City");
                        string? city = Console.ReadLine();
                        System.Console.WriteLine("Enter State");
                        string? state = Console.ReadLine();
                        var EmployeeModel = new EmployeeModel()
                        {
                            First_Name = Fname,
                            Last_name = Lname,
                            Dept_ID = Did,
                            Address = add,
                            City = city,
                            State = state
                        };
                        Add(EmployeeModel);
                        SaveChanges();
                        SuccessMessage();
                    break;
                default:
                    System.Console.WriteLine("Please enter a valid input!!!");
                    break;
            }
        }

        public void SuccessMessage()
        {
            System.Console.WriteLine("Task Performed Successfully");
        }
    }
}