using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentConsole.Models;

namespace VolunteerManagmentConsole.Services
{
    public class ManagmentService : IManagmentService    //ImanagmentService = visi Modelinterface
    {
        private readonly IDatabaseRepository _databaseRepository;
        public ManagmentService(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }
        public void AddVolunteer(VolunteerData volunteerData)
        {
            _databaseRepository.AddCandidate(volunteerData);
        }
        public void UpdateVolunteer(VolunteerData volunteerData)
        {
            _databaseRepository.UpdateCandidate(volunteerData);
        }
        public void DeleteCandidate(VolunteerData volunteerData)
        {
            _databaseRepository.DeleteCandidate(volunteerData);
        }
    }
}
