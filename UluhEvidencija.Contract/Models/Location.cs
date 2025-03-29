using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models
{
    public class Location : BaseEntity
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description{ get; set; }
        public int MaxCapacity { get; set; }
        public int LocationTypeID { get; set; }
        public int AddressID { get; set; }

        //Navigation properties
        public required LocationType LocationType { get; set; }
        public required Address Address { get; set; }
    }
}
