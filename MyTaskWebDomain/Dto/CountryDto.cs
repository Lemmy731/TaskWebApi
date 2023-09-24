using MyTaskWebDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebDomain.Dto
{
    public class CountryDto
    {
        public int CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetailsDto> CountryDetails { get; set; }
    }
}
