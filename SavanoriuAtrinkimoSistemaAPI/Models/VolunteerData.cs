using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerManagmentLibrary.Models;


namespace VolunteerManagmentAPI.Models
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
            DocumentsObj = documentsObj;
            VolunteerObj = volunteerObj;
        }
    }
}
