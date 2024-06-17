using Serilog;
using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentConsole.Models;
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
                Menu(ref inputMenu, ref managmentService, IdatabaseRepository);
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
            Console.WriteLine("2 - Koreguoti kandidato informacija.");
            Console.WriteLine("3 - Pakeisti kandidato duomenis.");
            Console.WriteLine("4 - Istrinti kandidata.");
            Console.WriteLine("");
            Console.WriteLine("0 - Baigti darba.");
        }
        public static void Menu(ref int inputMenu, ref ManagmentService managmentService, IDatabaseRepository databaseRepository)
        {
            switch (inputMenu)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    VolunteerData volunteerData = managmentService.CreateVolunteerData();
                    databaseRepository.AddCandidate(volunteerData);// ar  case'ai 1 ir 2 vienodai korektiski ar 1 reikia perkelti 63 eilute i managmentService, kaip funkcija
                    break;
                case 2:
                    managmentService.UpdateVolunteer();
                    break;
                case 3:
                    break;
                case 4:
                    managmentService.DeleteCandidate();
                    break;
                case 9:

                    break;
                default:
                    break;
            }
        }
    }
}
