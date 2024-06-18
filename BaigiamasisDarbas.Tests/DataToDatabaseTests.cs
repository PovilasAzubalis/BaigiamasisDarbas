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
        public void IdTransfer_bool_true()
        {
            //Arange
            ManagmentService managmentService = new ManagmentService(databaseRepository);
            Candidate candidate = new Candidate("test", "test", 5, "test@test.test", DateTime.Now);
            Details details = new Details("nothing", "nothing");
            Documents documents = new Documents();
            Volunteer volunteer = new Volunteer();
            VolunteerData volunteerData = new VolunteerData(candidate, details, documents, volunteer);
            volunteerData.CandidateObj.ID = 100;

            //Act
            int result = volunteerData.CandidateObj.ID;
            // Assert
            // neveikia... nors Candidate.ID gauna, priskirimas klaseje neveikia
            Assert.Equal(result, volunteerData.DetailsObj.ID);
        }
    }
}