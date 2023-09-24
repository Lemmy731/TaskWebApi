using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTaskWebApi.IService;
using MyTaskWebDomain.Dto;
using MyTaskWebDomain.Helper;

namespace MyTaskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumberController(IPhoneNumberService phoneNumberService)
        {
                _phoneNumberService = phoneNumberService;   
        }
        //endpoint to get phone number details
        [HttpGet]
        public async Task<ActionResult<Response<CountryInfo>>> GetDetail([FromQuery] PhoneNumberDto phoneNumberDto)
        {
           var response =  await _phoneNumberService.GetPhoneDetail(phoneNumberDto);
            if(response.Succeeded == true)
            {
                return Ok(response);
            }
            return BadRequest(response);    
        }
    }
}
