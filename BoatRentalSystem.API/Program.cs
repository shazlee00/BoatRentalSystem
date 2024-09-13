using BoatRentalSystem.API.Profiles;
using BoatRentalSystem.Application;
using BoatRentalSystem.Application.City.Query;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure;
using BoatRentalSystem.Infrastructure.Configurations;
using BoatRentalSystem.Infrastructure.Repositories;
using BoatSystem.Core.Interfaces;
using BoatSystem.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("customer", new OpenApiInfo { Title = "customer Api", Version = "v1" });
    options.SwaggerDoc("admin", new OpenApiInfo { Title = "Admin Api", Version = "v1" });
    options.SwaggerDoc("owner", new OpenApiInfo { Title = "Owner Api", Version = "v1" });
});


builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IAdditionRepository, AdditionRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IBoatRepository, BoatRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IBoatBookingRepository, BoatBookingRepository>();
builder.Services.AddScoped<IBookingAdditionRepository, BookingAdditionRepository>();
builder.Services.AddScoped<ICancellationRepository, CancellationRepository>();

builder.Services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
builder.Services.AddScoped<IReservationPaymentRepository, ReservationPaymentRepository>();
builder.Services.AddScoped<IBookingPaymentRepository, BookingPaymentRepository>();



builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<PackageService>();
builder.Services.AddScoped<AdditionService>();
builder.Services.AddScoped<BoatService>();
builder.Services.AddScoped<TripService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<BoatBookingService>();
builder.Services.AddScoped<BookingAdditionService>();
builder.Services.AddScoped<CancellationService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(
        Assembly.GetAssembly(typeof(ListCitiesQuery)),
        Assembly.GetAssembly(typeof(City))
        );
});




Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


builder.Host.UseSerilog();


Log.Information("Starting up");


builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(o =>
   {
       o.RequireHttpsMetadata = false;
       o.SaveToken = true;
       o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidIssuer = builder.Configuration["JWT:Issuer"],
           ValidAudience = builder.Configuration["JWT:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]
           ))
       };
   });


builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/{SwaggerDocsConstant.Admin}/swagger.json", "Admin Api");
        c.SwaggerEndpoint($"/swagger/{SwaggerDocsConstant.Customer}/swagger.json", "Customer Api");
        c.SwaggerEndpoint($"/swagger/{SwaggerDocsConstant.Owner}/swagger.json", "Owner Api");
    });

}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
