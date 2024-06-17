namespace VolunteerManagmentLibrary.Models
{
    public class Volunteer
    {
        public int ID { get; set; }
        
        // AGR - agreement
        public bool AGR { get; set; }
        public bool ParentAGR { get; set; }
        public int Available { get; set; }

        public Volunteer()
        {
            AGR = false;
            ParentAGR = false;
            Available = 0;
        }

    }
}
