
using Serilog;
using VolunteerManagmentConsole.Database_Repository;
namespace VolunteerManagmentConsole.Services
{
    public class UI
    {
        public static void Main(string[] args)
        {
            //string mainString = "C:\\Users\\azuba\\source\\repos\\BaigiamasisDarbas\\VolunteerManagmentConsole\\Database_Repository";
            // string connectionString = "Default" <-appsettings
            //StreamReader if file lines > 10 000
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
           .CreateLogger();

            string connectionString = "Data Source=DESKTOP-6FFNPQ7;Initial Catalog=VolunteerDB_Dapper;Integrated Security=True;Encrypt=False";

            IDatabaseRepository IdatabaseRepository = new DatabaseRepository(connectionString);
            ManagmentService managmentService = new ManagmentService(IdatabaseRepository);

            MenuText();
            MenuInputCheck(out bool inputMenuCheck, out int inputMenu);

            while (inputMenuCheck == true)
            {
                Menu(ref inputMenu, ref managmentService, ref IdatabaseRepository);
                Console.WriteLine();
                MenuText();
                MenuInputCheck(out inputMenuCheck, out inputMenu);
                
            }



        }
        public static (bool, int) MenuInputCheck(out bool inputMenuCheck, out int inputMenu)
        {
            inputMenuCheck = int.TryParse(Console.ReadLine(), out inputMenu);
            return (inputMenuCheck, inputMenu);
        }
        public static void MenuText()
        {
            Console.WriteLine("| MENU |");
            Console.WriteLine("1 - Prideti kandidata.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("0 - Baigti darba.");
        }
        public static void Menu(ref int inputMenu, ref ManagmentService managmentService, ref IDatabaseRepository IdatabaseRepository)
        {
            switch (inputMenu)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IdatabaseRepository.AddCandidate(managmentService.CreateCandidate(), managmentService.CreateDetails(), managmentService.CreateDocuments(), managmentService.CreateVolunteer());
                    break;
                case 2:
                    
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 9:

                    break;
                default:
                    break;
            }
        }
    }
}
