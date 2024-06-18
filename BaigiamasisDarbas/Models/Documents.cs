using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteersData.Models
{
    public class Documents
    {
        public int ID { get; set; }
        public string ParentAGRStatus { get; set; }
        public DateOnly PartentAGRDate { get; set; }
        public string AGRStatus { get; set; }
        public string AGRDate { get; set; }
    }
}
