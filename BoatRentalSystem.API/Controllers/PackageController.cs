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
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;
        private readonly IMapper _mapper;

        public PackageController(PackageService packageService, IMapper mapper)
        {
            _packageService = packageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageViewModel>>> Get()
        {
            var package = await _packageService.GetAllPackages();
            var packageViewModel = _mapper.Map<IEnumerable<PackageViewModel>>(package);
            return Ok(packageViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PackageViewModel>> Get(int id)
        {
            var package = await _packageService.GetPackageById(id);
            if (package == null)
            {
                return NotFound();
            }
            var packageViewModel = _mapper.Map<PackageViewModel>(package);
            return Ok(packageViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddPackageViewModel addPackageViewModel)
        {
            var package = _mapper.Map<Package>(addPackageViewModel);
            await _packageService.AddPackage(package);
            return CreatedAtAction(nameof(Get), new { id = package.Id }, addPackageViewModel);
        }

        [HttpPut]
        public async Task<ActionResult> Put(PackageViewModel packageViewModel)
        {
            var existingPackage = await _packageService.GetPackageById(packageViewModel.Id);
            if (existingPackage == null)
            {
                return NotFound();
            }
            var package = _mapper.Map<Package>(packageViewModel);
            await _packageService.UpdatePackage(package);
            return Ok(package);

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existingPackage = await _packageService.GetPackageById(id);
            if (existingPackage == null)
            {
                return NotFound();
            }
            await _packageService.DeletePackage(id);
            return NoContent();
        }
    }
}
