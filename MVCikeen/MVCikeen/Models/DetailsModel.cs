using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCikeen.Models
{
    public class DetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
    }
}