using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract;

namespace UluhEvidencija.Controller.Models
{
    public class Format : BaseEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public decimal WidthCm { get; set; }
        public decimal HeightCm { get; set; }
    }
}
