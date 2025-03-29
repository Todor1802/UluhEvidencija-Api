using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models
{
    public class LocationType : BaseEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        //navigation properties
        public ICollection<Location> Locations { get; set; }
    }
}
