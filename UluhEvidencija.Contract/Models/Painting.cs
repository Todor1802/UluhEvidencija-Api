using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models
{
    public class Painting : BaseEntity
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; }
        public required string PhotoPath { get; set; }
        public int? AuthorID { get; set; }
        public int? TechniqueID { get; set; }
        public int? FormatID { get; set; }
        public string? Description { get; set; }

        //Navigation properties
        public Author? Author{ get; set; }
        public Technique? Technique { get; set; }
        public Format? Format { get; set; }
    }
}
