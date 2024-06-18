using Serilog;
using System.Text.RegularExpressions;
using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentConsole.Models;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentConsole.Services
{
    public class ManagmentService : IManagmentService    //ImanagmentService = visi Modelinterface
    {
        private readonly IDatabaseRepository _databaseRepository;
        public ManagmentService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public Candidate CreateCandidate()
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
        public Documents CreateDocuments()
        {
            Documents documents = new Documents();
            return documents;
        }
        public Details CreateDetails()
        {
            Console.WriteLine("Komentarai:");
            string comments = Console.ReadLine();
            Console.WriteLine("Alegijos:");
            string allergies = Console.ReadLine();

            Details details = new Details(comments, allergies);
            return details;
        }
        public Volunteer CreateVolunteer()
        {
            Volunteer volunteer = new Volunteer();
            return volunteer;
        }
        public VolunteerData CreateVolunteerData()
        {
            VolunteerData volunteerData = new VolunteerData(CreateCandidate(), CreateDetails(), CreateDocuments(), CreateVolunteer());
            return volunteerData;
        }
        public void AddVolunteer(VolunteerData volunteerData)
        {
            _databaseRepository.AddCandidate(volunteerData);
        }
        public void UpdateVolunteer()
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
            _databaseRepository.UpdateCandidate(volunteerData);
        }
        public void DeleteCandidate()
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
            _databaseRepository.DeleteCandidate(volunteerData);
        }


    }
}
