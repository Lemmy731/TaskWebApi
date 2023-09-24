using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebDomain.Entity
{
    public class CountryDetailEntity
    {
        //entity for country detail table
        public int Id { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }
        public int CountryId { get; set; }
        public CountryEntity Country { get; set; }
    }
}
