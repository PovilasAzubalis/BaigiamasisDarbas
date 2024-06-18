using VolunteerManagmentLibrary.Models;


namespace VolunteerManagmentConsole.Models
{
    public class VolunteerData
    {
        public int ID { get; set; }
        public Candidate CandidateObj { get; set; }
        public Details DetailsObj { get; set; }
        public Documents DocumentsObj { get; set; }
        public Volunteer VolunteerObj { get; set; }
        public VolunteerData(Candidate candidateObj, Details detailsObj, Documents documentsObj, Volunteer volunteerObj)
        {
            CandidateObj = candidateObj;
            DetailsObj = detailsObj;
            DetailsObj.ID = CandidateObj.ID;
            DocumentsObj = documentsObj;
            DocumentsObj.ID = CandidateObj.ID;
            VolunteerObj = volunteerObj;
            VolunteerObj.ID = CandidateObj.ID;
        }
        public VolunteerData(int id)
        {
            ID = id;
        }
        public VolunteerData(Candidate candidateObj)
        {
            CandidateObj = candidateObj;
        }

        public VolunteerData(Documents documentsObj)
        {
            DocumentsObj = documentsObj;
        }
    }
}
