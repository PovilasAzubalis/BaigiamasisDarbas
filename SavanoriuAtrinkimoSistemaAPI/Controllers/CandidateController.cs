using Microsoft.AspNetCore.Mvc;
using VolunteerManagmentConsole.Database_Repository;
using VolunteerManagmentLibrary.Interfaces;
using VolunteerManagmentLibrary.Models;
namespace VolunteerManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly ICandidate _candidateService;
        private readonly IDetails _detailsService;
        private readonly IDocuments _documentsService;
        private readonly IVolunteer _volunteerService;
        public CandidateController(IDatabaseRepository _databaseRepository, ICandidate candidate, IDetails details, IDocuments documents, IVolunteer volunteer)
        {

            _candidateService = candidate;
            _detailsService = details;
            _documentsService = documents;
            _volunteerService = volunteer;
        }

        [HttpPost]
        public IActionResult AddCandidate(Candidate candidate, Details details, Documents documents, Volunteer volunteer)
        {
            // API class ClassName (candidate, details, documents, volunteer)
            _databaseRepository.AddCandidate(candidate, details, documents, volunteer);

            return Ok();
        }
    }

  
   
}
