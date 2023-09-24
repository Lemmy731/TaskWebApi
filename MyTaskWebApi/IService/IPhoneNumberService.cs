using MyTaskWebDomain.Dto;
using MyTaskWebDomain.Helper;

namespace MyTaskWebApi.IService
{
    public interface IPhoneNumberService
    {
        Task<Response<CountryInfo>> GetPhoneDetail(PhoneNumberDto phoneNumberDto);
    }
}
