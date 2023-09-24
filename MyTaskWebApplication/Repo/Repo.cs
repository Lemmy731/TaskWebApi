using Microsoft.EntityFrameworkCore;
using MyTaskWebApplication.Data;
using MyTaskWebDomain.Dto;
using MyTaskWebDomain.Entity;
using MyTaskWebDomain.Helper;
using MyTaskWebDomain.IRepo;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskWebApplication.Repo
{
    public class Repo: IRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly PhoneNumberUtil _phoneNumberUtil;
        public Repo()
        {
                
        }
        public Repo(AppDbContext appDbContext, PhoneNumberUtil phoneNumberUtil)
        {
            _appDbContext = appDbContext;
            _phoneNumberUtil = phoneNumberUtil; 
            
        }
        //CRUD operation for phone number details

        public async Task<CountryInfo> GetPhoneDetail(PhoneNumberDto phoneNumberDto)
        {
          
            PhoneNumber parsedPhoneNumber = _phoneNumberUtil.Parse(phoneNumberDto.PhoneNumber, null);
            int countryCode = parsedPhoneNumber.CountryCode;
            var countryss = _appDbContext.Countries.FirstOrDefault(c => c.CountryCode == countryCode);
            var countryDetails = _appDbContext.CountryDetails.Where(cd => cd.CountryId == countryss.Id)
            //    .Select(cd => new
            //{
            //    Operator = cd.Operator,
            //    OperatorCode = cd.OperatorCode
            //})
    .ToList();

            CountryDto country = new CountryDto
            {
                CountryCode = countryss.CountryCode,
                Name = countryss.Name,
                CountryIso = countryss.CountryIso,
                CountryDetails = countryDetails.Select(cd => new CountryDetailsDto
                {
                    Operator = cd.Operator,
                    OperatorCode = cd.OperatorCode
                }).ToList()
            };
            CountryInfo countryInfo = new CountryInfo()
            {
                Number = phoneNumberDto.PhoneNumber,
                Country = country
            };
            return countryInfo;
        }
    }
}
