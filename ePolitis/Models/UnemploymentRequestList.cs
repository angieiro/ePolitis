using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class UnemploymentRequestList
    {
        public List<UnemploymentRequest> RequestList { get; set; }
        public UnemploymentRequestList()
        {
            RequestList = new List<UnemploymentRequest>();
        }
    }
}