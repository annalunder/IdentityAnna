using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Models
{
    public class Cities
    {
        public int? CityId { get; set; }
        public string CityName { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int CountryId { get; set; }
        public Countries Country { get; set; }
    }
}
