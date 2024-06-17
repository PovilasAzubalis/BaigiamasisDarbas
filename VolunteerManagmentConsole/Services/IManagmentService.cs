using VolunteerManagmentConsole.Models;
using VolunteerManagmentLibrary.Interfaces;

namespace VolunteerManagmentConsole.Services
{
    public interface IManagmentService : ICandidate, IDetails, IDocuments, IVolunteer
    {
        public VolunteerData CreateVolunteerData();

    }
}
