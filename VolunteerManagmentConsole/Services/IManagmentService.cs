using VolunteerManagmentConsole.Models;
using VolunteerManagmentLibrary.Interfaces;

namespace VolunteerManagmentConsole.Services
{
    public interface IManagmentService
    {
        void AddVolunteer(VolunteerData volunteerData);
        void UpdateVolunteer(VolunteerData volunteerData);
        void DeleteCandidate(VolunteerData volunteerData);

    }
}
