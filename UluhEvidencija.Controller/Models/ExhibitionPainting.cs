using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract;

namespace UluhEvidencija.Controller.Models
{
    public class ExhibitionPainting : BaseEntity
    {
        public int ExhibitionID { get; set; }
        public int PaintingID { get; set; }
        public int? DisplayOrder { get; set; }

        //Navigation properties
        public required Exhibition Exhibition { get; set; }
        public required Painting Painting { get; set; }
    }
}
