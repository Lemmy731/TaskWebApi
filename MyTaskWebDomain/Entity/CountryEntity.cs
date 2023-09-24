using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebDomain.Entity
{
    public class CountryEntity
    {
        //entity for country table
        public int Id { get; set; }
        public int CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetailEntity> CountryDetails { get; set; }
    }
}
