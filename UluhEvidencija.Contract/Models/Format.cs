using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models
{
    public class Format : BaseEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public decimal WidthCm { get; set; }
        public decimal HeightCm { get; set; }
        //Navigation properties
        public ICollection<Painting> Paintings { get; set; }
    }
}
