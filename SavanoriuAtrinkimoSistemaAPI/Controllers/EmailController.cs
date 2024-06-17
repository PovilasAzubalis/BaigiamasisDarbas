using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using VolunteerManagmentLibrary;
using VolunteerManagmentLibrary.Models;

namespace VolunteerManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddCandidate(string body)
        {
            return null;
        }
    }
}
