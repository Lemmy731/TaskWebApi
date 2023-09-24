using MyTaskWebDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebDomain.Dto
{
    //output class
    public class CountryInfo
    {
        public string Number { get; set; }
        public CountryDto Country { get; set; }
    }
}
