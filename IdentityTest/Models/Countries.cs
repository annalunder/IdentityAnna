using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Models
{
    public class Countries
    {
        public int? CountryId { get; set; }
        public string CountryName { get; set; }

        public List<Cities> Cities { get; set; }
    }
}
