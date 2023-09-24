using AutoMapper;
using MyTaskWebApi.IService;
using MyTaskWebDomain.Dto;
using MyTaskWebDomain.Helper;
using MyTaskWebDomain.IRepo;

namespace MyTaskWebApi.Service
{
    public class PhoneNumberService: IPhoneNumberService
    {
        private readonly IRepo _repo;
        private readonly ILogger<PhoneNumberService> _logger;

        public PhoneNumberService(IRepo repository,ILogger<PhoneNumberService> logger)
        {
            _repo = repository;  
            _logger = logger;   
        }

        public async Task<Response<CountryInfo>> GetPhoneDetail(PhoneNumberDto phoneNumberDto)
        {
            try
            {
                if (phoneNumberDto != null) 
                {
                    var result = await _repo.GetPhoneDetail(phoneNumberDto);
                    if(result.Number == phoneNumberDto.PhoneNumber)
                    {
                        return Response<CountryInfo>.Success("Successful", result, 200);
                    }
                }
                return Response<CountryInfo>.Fail($"No data found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                return Response<CountryInfo>.Fail("An error occurred while processing your request.", 500);
            }
        }
    }
}
