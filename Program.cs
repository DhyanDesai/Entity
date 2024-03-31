namespace Entity;

class Program
{
    static async Task Main(string[] args)
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
                System.Console.WriteLine("4.DELETE Data.");
                System.Console.WriteLine("5.Exit");
                System.Console.WriteLine("Enter an option :");
                menuInput = Convert.ToInt32(Console.ReadLine());
                switch (menuInput)
                {
                    case 1:
                        contextClass.ShowData();
                        break;
                    case 2:
                         await contextClass.AddData();
                        break;
                    case 3:
                        await contextClass.UpdateData();
                        break;
                    case 4:
                        await contextClass.DeleteData();
                    break;
                    case 5:
                        System.Console.WriteLine("Thank You!!!");
                        break;
                    default:
                        DbContext.InvalidInputMessage();
                        break;
                }
            } while (menuInput != 5);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
            // System.Console.WriteLine(e.InnerException.Message);
        }
    }
}
