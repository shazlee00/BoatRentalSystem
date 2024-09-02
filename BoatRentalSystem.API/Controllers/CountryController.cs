namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.API.ViewModels;
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Application.Services;
    using BoatRentalSystem.Core.Entities;
    using BoatSystem.Core.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = SwaggerDocsConstant.Admin)]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(CountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryViewModel>>> Get()
        {
            var country = await _countryService.GetAllCountries();
            var countryViewModel = _mapper.Map<IEnumerable<CountryViewModel>>(country);
            return Ok(countryViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryViewModel>> Get(int id)
        {
            var country = await _countryService.GetCountryById(id);
            if (country == null)
            {
                return NotFound();
            }
            var countryViewModel = _mapper.Map<CountryViewModel>(country);
            return Ok(countryViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddCountryViewModel addCountryViewModel)
        {
            var country = _mapper.Map<Country>(addCountryViewModel);
            await _countryService.AddCountry(country);
            return CreatedAtAction(nameof(Get), new { id = country.Id }, addCountryViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CountryViewModel countryViewModel)
        {
            var existingCountry = await _countryService.GetCountryById(countryViewModel.Id);
            if (existingCountry == null)
            {
                return NotFound();
            }
            var country = _mapper.Map<Country>(countryViewModel);
            await _countryService.UpdateCountry(country);
            return Ok(country);

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCountry = await _countryService.GetCountryById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }
            await _countryService.DeleteCountry(id);
            return NoContent();
        }
    }
}
