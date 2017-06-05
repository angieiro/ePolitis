using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePolitis.Models
{
    public class History
    {
        public List<string> Visits { get; set; }
        public History()
        {
            Visits = new List<string>();
        }
    }
}