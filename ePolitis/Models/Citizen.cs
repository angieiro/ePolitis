using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class Citizen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Afm { get; set; }
        public string Amka { get; set; }
        public string Ama { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string BirthLocation { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public string IdNumber { get; set; }
        public string PassportNumber { get; set; }

        public string AmOaed { get; set; }
        public string CardOaed { get; set; }

        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public string AreaCode { get; set; }
        public string County { get; set; }
        public string City { get; set; }



        [ForeignKey("User")]
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}