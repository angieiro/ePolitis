using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }        public string WorkPhone { get; set; }
        

        [ForeignKey("Citizen")]
        public string Afm { get; set; }
        public virtual Citizen Citizen { get; set; }

    }
}