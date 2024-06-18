using Microsoft.AspNetCore.Mvc;
using VolunteerManagmentConsole.Models;
using VolunteerManagmentConsole.Services;
namespace VolunteerManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IManagmentService _managmentService;
        public VolunteerController(IManagmentService managmentService)
        {
            _managmentService = managmentService;
        }
        [Route("AddCandidates")]
        [HttpPost]
        public IActionResult AddCandidate(VolunteerData volunteerData)
        {
            volunteerData = new VolunteerData(volunteerData.CandidateObj);
            AddCandidate(volunteerData);

            return Ok();
        }
        [Route("AddDocuments")]
        [HttpPost]
        public IActionResult AddDocuments(VolunteerData volunteerData)
        {
            volunteerData = new VolunteerData(volunteerData.DocumentsObj);
            AddDocuments(volunteerData);

            return Ok();
        }

    }



}
