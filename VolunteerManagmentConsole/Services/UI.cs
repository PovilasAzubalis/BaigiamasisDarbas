using Serilog;
using System.Text.RegularExpressions;
using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentConsole.Models;
using VolunteerManagmentLibrary.Models;
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
                Menu(ref inputMenu, ref managmentService);
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
        public static void Menu(ref int inputMenu, ref ManagmentService managmentService)
        {
            switch (inputMenu)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    VolunteerData volunteerData = CreateVolunteerData();
                    managmentService.AddVolunteer(volunteerData);
                    break;
                case 2:
                    VolunteerData volunteerUpdate =  inputUpdateVolunteer();
                    managmentService.UpdateVolunteer(volunteerUpdate);
                    break;
                case 3:
                    break;
                case 4:
                    VolunteerData volunteerDelete = inputDeleteVolunteer();
                    managmentService.DeleteCandidate(volunteerDelete);
                    break;
                case 9:

                    break;
                default:
                    break;
            }
        }
        public static Candidate CreateCandidate()
        {
            Console.Write("Vardas:");
            string? name = Console.ReadLine();

            Console.Write("Pavarde:");
            string? surname = Console.ReadLine();

            Console.Write("El. pastas:");
        emailCheck:
            string? email = Console.ReadLine();
            Regex emailregex = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
            Match m = emailregex.Match(email);
            if (m.Success)
            {

            }
            else
            {
                Console.WriteLine(email + " is not a valid email address. Iveskite is naujo ");
                goto emailCheck;
            }



            Console.Write("Telefono Nr.:");
            int phoneNr;
        phoneNrCheck:
            try
            {
                phoneNr = int.Parse(Console.ReadLine());
            }
            catch (Exception BlogaIvestis)
            {
                Console.WriteLine(BlogaIvestis.Message);
                goto phoneNrCheck;
            }

            string d = "yyyy-mm-dd";
            Console.Write($"Gimimo data formatu {d}:");
        dobCheck:
            string dob = Console.ReadLine();
            Regex dobregex = new Regex("\\d{4}-\\d{2}-\\d{2}");
            Match D = dobregex.Match(dob);

            DateTime DOB;
            if (D.Success)
            {
                DOB = DateTime.Parse(dob);
            }
            else
            {
                Console.WriteLine(dob + " is not a valid date format. Try again ");
                goto dobCheck;
            }


            Candidate candidate = new Candidate(name, surname, phoneNr, email, DOB);
            Log.Information("Candidate Created");
            return candidate;
        }
        public static Documents CreateDocuments()
        {
            Documents documents = new Documents();
            return documents;
        }
        public static Details CreateDetails()
        {
            Console.WriteLine("Komentarai:");
            string comments = Console.ReadLine();
            Console.WriteLine("Alegijos:");
            string allergies = Console.ReadLine();

            Details details = new Details(comments, allergies);
            return details;
        }
        public static Volunteer CreateVolunteer()
        {
            Volunteer volunteer = new Volunteer();
            return volunteer;
        }
        public static VolunteerData CreateVolunteerData()
        {
            VolunteerData volunteerData = new VolunteerData(CreateCandidate(), CreateDetails(), CreateDocuments(), CreateVolunteer());
            return volunteerData;
        }

        public static VolunteerData inputUpdateVolunteer()
        {
        IDCheck:
            Console.Write("Iveskite savanorio ID: ");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto IDCheck;
            }

            Candidate candidate = CreateCandidate();
            VolunteerData volunteerData = new VolunteerData(candidate);
            volunteerData.CandidateObj.ID = id;
            return volunteerData;
        }
        public static VolunteerData inputDeleteVolunteer()
        {

        IDCheck:
            Console.Write("Iveskite savanorio ID: ");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto IDCheck;
            }
            VolunteerData volunteerData = new VolunteerData(id);
            return volunteerData;

        }
    }
}
