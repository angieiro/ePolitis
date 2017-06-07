using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class UnemploymentRequest
    {
        [Key]
        public int RequestId { get; set; }
        public bool Approved { get; set; }

        [ForeignKey("Employee")]
        public int Afm { get; set; }
        public Employee Employee { get; set; }
        //public virtual ICollection<Employee> Applicants { get; set; }
    }
}