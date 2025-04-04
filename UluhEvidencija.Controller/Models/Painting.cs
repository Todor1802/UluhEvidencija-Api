using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract;

namespace UluhEvidencija.Controller.Models
{
    public class Painting : BaseEntity
    {
        public required string Title { get; set; }
        public int Year { get; set; }
        public required string PhotoPath { get; set; }
        public int? AuthorID { get; set; }
        public int? TechniqueID { get; set; }
        public int? FormatID { get; set; }
        public string? Description { get; set; }
    }
}
