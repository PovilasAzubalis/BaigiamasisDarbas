using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerManagmentLibrary.Models
{
    public class Details
    {
        int ID { get; set; }
        string? Comments { get; set; }
        string? Allergies { get; set; }
        string? CommentsOrg { get; set; }

    }
}
