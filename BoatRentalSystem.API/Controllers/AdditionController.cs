namespace BoatRentalSystem.API.Controllers
{
    using AutoMapper;
    using BoatRentalSystem.API.ViewModels;
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Core.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AdditionController : ControllerBase
    {
        private readonly AdditionService _additionService;
        private readonly IMapper _mapper;

        public AdditionController(AdditionService additionService, IMapper mapper)
        {
            _additionService = additionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionViewModel>>> Get()
        {
            var addition = await _additionService.GetAllAdditions();
            var additionViewModel = _mapper.Map<IEnumerable<AdditionViewModel>>(addition);
            return Ok(additionViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionViewModel>> Get(int id)
        {
            var addition = await _additionService.GetAdditionById(id);
            if (addition == null)
            {
                return NotFound();
            }
            var additionViewModel = _mapper.Map<AdditionViewModel>(addition);
            return Ok(additionViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddAdditionViewModel addAdditionViewModel)
        {
            var addition = _mapper.Map<Addition>(addAdditionViewModel);
            await _additionService.AddAddition(addition);
            return CreatedAtAction(nameof(Get), new { id = addition.Id }, addAdditionViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(AdditionViewModel additionViewModel)
        {
            var existingAddition = await _additionService.GetAdditionById(additionViewModel.Id);
            if (existingAddition == null)
            {
                return NotFound();
            }
            var addition = _mapper.Map<Addition>(additionViewModel);
            await _additionService.UpdateAddition(addition);
            return Ok(addition);

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingAddition = await _additionService.GetAdditionById(id);
            if (existingAddition == null)
            {
                return NotFound();
            }
            await _additionService.DeleteAddition(id);
            return NoContent();
        }
    }
}
