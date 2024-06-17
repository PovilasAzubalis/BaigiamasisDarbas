using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentConsole.Database_Repository
{
    public interface IDatabaseRepository
    {
        void AddCandidate(Candidate candidate, Details details, Documents documents, Volunteer volunteer);
        void UpdateDocuments(Documents documents);
        void AddVolunteerToTeam(Volunteer volunteer);  //skiped 
        void DeleteCandidate(Candidate candidate, Details details, Documents documents, Volunteer volunteer); // perdeti i faila (veliau)
    }
}
