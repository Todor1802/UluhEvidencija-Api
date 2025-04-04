using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UluhEvidencija.Contract;

namespace UluhEvidencija.Controller.Models
{
    public class Author : BaseEntity
    {
        public int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Biography { get; set; }
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? ProfilePhotoPath { get; set; }
    }
}
