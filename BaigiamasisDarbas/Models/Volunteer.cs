namespace VolunteersData.Models
{
    public class Volunteer
    {
        public int ID { get; set; }
        public bool Available { get; set; }
        // AGR - agreement
        public bool ParentAGR { get; set; }
        public bool VolunteerAGR { get; set; }

    }
}
