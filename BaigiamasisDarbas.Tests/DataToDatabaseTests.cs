using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentConsole.Models;
using VolunteerManagmentConsole.Services;
using VolunteerManagmentLibrary.Models;

namespace BaigiamasisDarbas.Tests
{
    public class DataToDatabaseTests
    {
        IManagmentService? managmentService;
        IDatabaseRepository? databaseRepository;
        [Fact]
        public void CandidateObjCreationCheck_True()
        {
            //Arange
            ManagmentService managmentService = new ManagmentService(databaseRepository);
            Candidate candidate = new Candidate("test", "test", 5, "test@test.test", DateTime.Now);
            Details details = new Details("nothing", "nothing");
            Documents documents = new Documents();
            Volunteer volunteer = new Volunteer();
            VolunteerData volunteerData = new VolunteerData(candidate, details, documents, volunteer);

            //Act
            Candidate resultCandidate = candidate;
            // Assert
            Assert.Equal(resultCandidate, volunteerData.CandidateObj);
        }
    }
}