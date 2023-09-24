using Microsoft.EntityFrameworkCore;
using MyTaskWebApi.IService;
using MyTaskWebApi.Seed;
using MyTaskWebApi.Service;
using MyTaskWebApplication.Data;
using MyTaskWebApplication.Repo;
using MyTaskWebDomain.IRepo;
using PhoneNumbers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("MyDb")
);
builder.Services.AddSingleton<PhoneNumberUtil>(PhoneNumberUtil.GetInstance());
builder.Services.AddLogging();
builder.Services.AddScoped<SeedData>();

builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedData.Seed(app);

app.Run();
