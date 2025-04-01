using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract;

namespace UluhEvidencija.Controller.Models
{
    public class Address : BaseEntity
    {
        public int ID { get; set; }
        public required string FreeFormAddress { get; set; }

        //navigation properties
        public ICollection<Location> Locations { get; set; }
    }
}
