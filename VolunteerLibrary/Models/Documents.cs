using VolunteerManagmentLibrary.Constants;

namespace VolunteerManagmentLibrary.Models
{
    public class Documents
    {
        public int ID { get; set; }
        // AGR - agreement
        public string? ParentAGRStatus { get; set; }
        public DateTime ParentAGRDate { get; set; }
        public string? AGRStatus { get; set; }
        public DateTime AGRDate { get; set; }

        public Documents()
        {
            ParentAGRStatus = AgreementStatus.NS;
            ParentAGRDate = DateTime.Today;

            AGRStatus = AgreementStatus.NS;
            AGRDate = DateTime.Today;
        }
    }
}
