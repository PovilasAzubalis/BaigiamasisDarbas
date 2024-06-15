namespace VolunteerManagmentLibrary.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PhoneNr { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
