using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models
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
        //Navigation properties
        public required Location Location { get; set; }
        public ICollection<ExhibitionPainting> ExhibitionPaintings { get; set; }
    }
}
