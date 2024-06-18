namespace VolunteerManagmentLibrary.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int PhoneNr { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public Candidate(string? name, string? surname, int phoneNr, string? email, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            PhoneNr = phoneNr;
            Email = email;
            DateOfBirth = dateOfBirth;
            Age = (DateTime.Today - DateOfBirth).Days/365;
            
        }
        public Candidate(int id, string? name, string? surname, int phoneNr, string? email, DateTime dateOfBirth)
        {
            ID = id;
            Name = name;
            Surname = surname;
            PhoneNr = phoneNr;
            Email = email;
            DateOfBirth = dateOfBirth;
            Age = (DateTime.Today - DateOfBirth).Days / 365;
        }


    }
}
