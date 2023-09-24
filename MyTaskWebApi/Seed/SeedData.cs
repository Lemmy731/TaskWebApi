using MyTaskWebApplication.Data;
using MyTaskWebDomain.Entity;
using System.Diagnostics.Metrics;

namespace MyTaskWebApi.Seed
{
    public  class SeedData
    {
        private  readonly AppDbContext _context;

        //seed data into the in memory database
        public SeedData()
        {
                
        }
        public  SeedData(AppDbContext context)
        {
                _context = context;   
        }
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            //SeedData seedData = new SeedData();
            //var contex = seedData._context;
            //var cont = contex.Database.EnsureCreated();

            using (var createScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = createScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Countries.Any())
                {
                    var countries = new List<CountryEntity>
            {
                new CountryEntity { CountryCode = 234, Name = "Nigeria", CountryIso = "NG" },
                new CountryEntity { CountryCode = 233, Name = "Ghana", CountryIso = "GH" },
                new CountryEntity { CountryCode = 229, Name = "Benin Republic", CountryIso = "BN" },
                new CountryEntity { CountryCode = 225, Name = "Côte d'Ivoire", CountryIso = "CIV" },
                    };

                    context.Countries.AddRange(countries);
                    context.SaveChanges();
                }

                if (!context.CountryDetails.Any())
                {
                    var countryDetails = new List<CountryDetailEntity>
            {
                new CountryDetailEntity { CountryId = 1, Operator = "MTN Nigeria", OperatorCode = "MTN NG" },
                new CountryDetailEntity { CountryId = 1, Operator = "Airtel Nigeria", OperatorCode = "ANG" },
                new CountryDetailEntity { CountryId = 1, Operator = "9 Mobile Nigeria", OperatorCode = "ETN" },
                new CountryDetailEntity { CountryId = 1, Operator = "Globacom Nigeria", OperatorCode = "GLO NG" },
                new CountryDetailEntity { CountryId = 2, Operator = "Vodafone Ghana", OperatorCode = "Vodafone GH" },
                new CountryDetailEntity { CountryId = 2, Operator = "MTN Ghana", OperatorCode = "MTN GH" },
                new CountryDetailEntity { CountryId = 2, Operator = "Tigo Ghana", OperatorCode = "Tigo GH" },
                new CountryDetailEntity { CountryId = 3, Operator = "MTN Benin", OperatorCode = "MTN Benin" },
                new CountryDetailEntity { CountryId = 3, Operator = "Moov Benin", OperatorCode = "Moov Benin" },
                new CountryDetailEntity { CountryId = 4, Operator = "MTN Côte d'Ivoire", OperatorCode = "MTN CIV" },
                    };

                    context.CountryDetails.AddRange(countryDetails);
                    context.SaveChanges();
                }
            }

        }

        
    }
}
