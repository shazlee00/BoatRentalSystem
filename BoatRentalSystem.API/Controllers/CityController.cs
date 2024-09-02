namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.API.ViewModels;
    using BoatRentalSystem.Application.City.Command.Add;
    using BoatRentalSystem.Application.City.Command.Update;
    using BoatRentalSystem.Application.City.Query;
    using BoatRentalSystem.Application.Services;
    using BoatRentalSystem.Core.Entities;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CityController(CityService cityService, IMapper mapper, IMediator mediator)
        {
            _cityService = cityService;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityViewModel>>> Get()
        {
            //var city = await _cityService.GetAllCities();
            //var cityViewModel = _mapper.Map<IEnumerable<CityViewModel>>(city);

            var query=new ListCitiesQuery();

            var cityViewModel = await _mediator.Send(query);

            return Ok(cityViewModel);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CityViewModel>> Get(int id)
        {
            //var city = await _cityService.GetCityById(id);
            //if (city == null)
            //{
            //    return NotFound();
            //}
            //var cityViewModel = _mapper.Map<CityViewModel>(city);

            var query = new GetCityQuery(id);

            var cityViewModel= await _mediator.Send(query);

            if (cityViewModel == null)
            {
                return NotFound();
            }


            return Ok(cityViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddCityCommand command)
        {
            //var city = _mapper.Map<City>(addCityViewModel);
            //await _cityService.AddCity(city);

            if (command == null)
            {
                return BadRequest("City data is required");
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateCityCommand command)
        {
            //var existingCity = await _cityService.GetCityById(cityViewModel.Id);
            //if (existingCity == null)
            //{
            //    return NotFound();
            //}
            //var city = _mapper.Map<City>(cityViewModel);
            //await _cityService.UpdateCity(city);



            var result = await _mediator.Send(command);
            if (result == null)
            {
                return BadRequest("error in update city");
            }
            return Ok(result);


        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingCity = await _cityService.GetCityById(id);
            if (existingCity == null)
            {
                return NotFound();
            }
            await _cityService.DeleteCity(id);
            return NoContent();
        }
    }
}
