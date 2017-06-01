using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class UnemploymentRequest
    {
        [Key]
        public int RequestId { get; set; }

        public virtual ICollection<Employee> Applicants { get; set; }
    }
}