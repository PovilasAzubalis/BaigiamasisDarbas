using Microsoft.Identity.Client;
using Serilog;
using System.Text.RegularExpressions;
using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentLibrary.Interfaces;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentConsole.Services
{
    public class ManagmentService : ICandidate, IDocuments, IDetails, IVolunteer    //ImanagmentService = visi Modelinterface
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

        public void CreateCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
