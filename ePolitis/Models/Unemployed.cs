using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class Unemployed
    {
        [Key]
        public int Afm { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Ama { get; set; }

        public long Amka { get; set; }
        public string BirthLocation { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public long AmOaed { get; set; }
        public string CardOaed { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }

        public string Phone { get; set; }
        public string MobilePhone { get; set; }

        public string AddressStreet { get; set; }
        public int AddressNumber { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public int AreaCode { get; set; }
        public string County { get; set; }

        public string FileApplicationPath { get; set; }

        [ForeignKey("User")]
        public string Email { get; set; }
        public virtual User User { get; set; }
    }
}