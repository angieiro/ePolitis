﻿using System;
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
        public string Gender { get; set; }

        public String DateOfBirth { get; set; }

        public int Ama { get; set; }

        public long Amka { get; set; }

        public string BirthLocation { get; set; }

        public string Country { get; set; }

        public string Nationality { get; set; }

        public string IdNumber { get; set; }

        public string PassportNumber { get; set; }



        public string Phone { get; set; }

        public string MobilePhone { get; set; }



        public string AddressStreet { get; set; }

        public int AddressNumber { get; set; }

        public int AreaCode { get; set; }

        public string County { get; set; }



        [ForeignKey("User")]
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}