using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerManagmentConsole.Models;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentConsole.Database_Repository
{
    public interface IDatabaseRepository
    {
        void AddCandidate(VolunteerData volunteerData);
        void UpdateCandidate(VolunteerData volunteerData);
        void UpdateDocuments(VolunteerData volunteerData);
        void AddVolunteerToTeam(VolunteerData volunteerData);  //skiped 
        void DeleteCandidate(VolunteerData volunteerData); // perdeti i faila (veliau)
    }
}
