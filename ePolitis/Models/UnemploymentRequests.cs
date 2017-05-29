using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class UnemploymentRequests
    {
        public int RequestId { get; set; }

        public virtual ICollection<Employee> Applicants { get; set; }
    }
}