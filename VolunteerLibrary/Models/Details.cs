namespace VolunteerManagmentLibrary.Models
{
    public class Details
    {
        public int ID { get; set; }
        public string? Comments { get; set; }
        public string? Allergies { get; set; }
        public string? CommentsOrg { get; set; }

        public Details(string? comments, string? allergies)
        {
            Comments = comments;
            Allergies = allergies;
        }
    }
}
