namespace Entity;

class Program
{
    static void Main(string[] args)
    {
        var DbContext = new DemoDbContext();
        try
        {   
            int a =0;   
            do
            {
                System.Console.WriteLine("Entity Framework Core Practice");
                System.Console.WriteLine("1.SHOW All Data Department Table.");
                System.Console.WriteLine("2.SHOW All Data Employee Table.");
                System.Console.WriteLine("3.ADD Data in Department Table.");
                System.Console.WriteLine("4.ADD Data in Employee Table");
                System.Console.WriteLine("5.UPDATE Data in Department Table.");
                System.Console.WriteLine("6.UPDATE Data in Employee Table.");
                System.Console.WriteLine("7.Exit");
                System.Console.WriteLine("Enter an option :");
                a = Convert.ToInt32(Console.ReadLine());  
                switch (a)
                {
                    case 1:                        
                        foreach (var item in DbContext.DepartmentModel)
                        {
                            System.Console.WriteLine($"ID : {item.ID}  , Name : {item.Dept_Name} ");
                        }
                    break;
                    case 2:
                        foreach (var item in DbContext.EmployeeModel)
                        {
                            System.Console.WriteLine($"ID : {item.ID} , FirstName : {item.First_Name} , LastName : {item.Last_name} , Department_ID : {item.Dept_ID} , Address : {item.Address} , City : {item.City} , State : {item.State}");
                        }
                    break;
                    case 3:
                        System.Console.WriteLine("Enter Department values:");
                        System.Console.WriteLine("Enter Department Name");
                        string? Dname = Console.ReadLine();
                        var DepartmentModel = new DepartmentModel(){
                            Dept_Name = Dname

                        };
                        DbContext.DepartmentModel.Add(DepartmentModel); 
                        DbContext.SaveChanges();
                        System.Console.WriteLine("Values Added");
                    break;
                    case 4:
                        System.Console.WriteLine("Enter Employee values:");
                        System.Console.WriteLine("Enter First Name");
                        string? Fname = Console.ReadLine();
                        System.Console.WriteLine("Enter Last Name");
                        string? Lname = Console.ReadLine();
                        System.Console.WriteLine("Enter Department ID");
                        int Did = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter Address");
                        string? Add = Console.ReadLine();
                        System.Console.WriteLine("Enter City");
                        string? city = Console.ReadLine();
                        System.Console.WriteLine("Enter State");
                        string? state = Console.ReadLine();
                        var EmployeeModel = new EmployeeModel(){
                            First_Name=Fname,
                            Last_name=Lname,
                            Dept_ID=Did,
                            Address=Add,
                            City=city,
                            State=state
                        };
                        DbContext.EmployeeModel.Add(EmployeeModel); 
                        DbContext.SaveChanges();
                        System.Console.WriteLine("Values Added");
                    break;
                    case 5:
                        System.Console.WriteLine("Enter ID where you want to update Name");
                        int id = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Enter New Department Name to Update");
                        string? Uname = Console.ReadLine();
                        var UpdateDepartment = new DepartmentModel(){
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
                        var UpdateEmployee = new EmployeeModel(){
                            ID = Eid,
                            First_Name=EFname,
                            Last_name=ELname,
                            Dept_ID=EDid,
                            Address=EAdd,
                            City=Ecity,
                            State=Estate
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
            } while ( a != 7);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            // System.Console.WriteLine(e.InnerException.Message);
        }
    }
}
