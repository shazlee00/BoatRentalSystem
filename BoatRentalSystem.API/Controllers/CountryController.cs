namespace BoatRentalSystem.API.Controllers
{
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Core.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public Task<IEnumerable<Country>> Get()
        {
            return _countryService.GetAllCountries();
        }

        [HttpGet("{id}")]
        public Task<Country> Get(int id)
        {
            return _countryService.GetCountryById(id);
        }

        [HttpPost]
        public Task Post(Country country)
        {
            return _countryService.AddCountry(country);
        }

        [HttpPut]
        public Task Put(Country country)
        {
            return _countryService.UpdateCountry(country);

        }
        [HttpDelete]
        public Task Delete(int id)
        {
            return _countryService.DeleteCountry(id);
        }
    }
}
