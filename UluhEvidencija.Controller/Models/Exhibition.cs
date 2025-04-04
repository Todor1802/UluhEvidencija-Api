using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract;

namespace UluhEvidencija.Controller.Models
{
    public class Exhibition : BaseEntity
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CoverImagePath { get; set; }
        public bool IsActive { get; set; }
        public int LocationID { get; set; }
    }
}
