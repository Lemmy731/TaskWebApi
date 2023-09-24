using MyTaskWebDomain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebDomain.IRepo
{
    public interface IRepo
    {
        Task<CountryInfo> GetPhoneDetail(PhoneNumberDto phoneNumberDto);
    }
}
