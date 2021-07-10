using IdentityTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTest.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CityName { get; set; }
      
        public string CountryName { get; set; }
    }
}
