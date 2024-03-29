namespace Entity;

class Program
{
    static void Main(string[] args)
    {
        DemoDbContext contextClass = new DemoDbContext();
        var DbContext = new DemoDbContext();
        try
        {
            int menuInput = 0;
            do
            {
                System.Console.WriteLine("Entity Framework Core Practice");
                System.Console.WriteLine("1.SHOW Data.");
                System.Console.WriteLine("2.ADD Data.");
                System.Console.WriteLine("3.UPDATE Data.");
                System.Console.WriteLine("4.Exit");
                System.Console.WriteLine("Enter an option :");
                menuInput = Convert.ToInt32(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                        contextClass.ShowData();
                        break;
                    case 2:
                        contextClass.AddData();
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        System.Console.WriteLine("Enter ID where you want to update Name");
                        int id = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter New Department Name to Update");
                        string? Uname = Console.ReadLine();
                        var UpdateDepartment = new DepartmentModel()
                        {
                            ID = id,
                            Dept_Name = Uname
                        };
                        DbContext.DepartmentModel.Update(UpdateDepartment);
                        DbContext.SaveChanges();
                        System.Console.WriteLine("Update Successfull!!!!");
                        break;
                    case 6:
                        System.Console.WriteLine("Enter ID where you want to update Name");
                        int Eid = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter new First Name");
                        string? EFname = Console.ReadLine();
                        System.Console.WriteLine("Enter new Last Name");
                        string? ELname = Console.ReadLine();
                        System.Console.WriteLine("Enter new Department ID");
                        int EDid = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter new Address");
                        string? EAdd = Console.ReadLine();
                        System.Console.WriteLine("Enter new City");
                        string? Ecity = Console.ReadLine();
                        System.Console.WriteLine("Enter new State");
                        string? Estate = Console.ReadLine();
                        var UpdateEmployee = new EmployeeModel()
                        {
                            ID = Eid,
                            First_Name = EFname,
                            Last_name = ELname,
                            Dept_ID = EDid,
                            Address = EAdd,
                            City = Ecity,
                            State = Estate
                        };
                        DbContext.EmployeeModel.Update(UpdateEmployee);
                        DbContext.SaveChanges();
                        System.Console.WriteLine("Update Successfull!!!!");
                        break;
                    case 7:
                        System.Console.WriteLine("BYEEEE");
                        break;
                    default:
                        System.Console.WriteLine("Invalid Input");
                        break;
                }
            } while (menuInput != 7);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            // System.Console.WriteLine(e.InnerException.Message);
        }
    }
}
