namespace BoatRentalSystem.API.Controllers
{
    using BoatRentalSystem.Application;
    using BoatRentalSystem.Core.Entities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;

        public PackageController(PackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public Task<IEnumerable<Package>> Get()
        {
            return _packageService.GetAllPackages();
        }

        [HttpGet("{id}")]
        public Task<Package> Get(int id)
        {
            return _packageService.GetPackageById(id);
        }

        [HttpPost]
        public Task Post(Package package)
        {
            return _packageService.AddPackage(package);
        }

        [HttpPut]
        public Task Put(Package package)
        {
            return _packageService.UpdatePackage(package);

        }
        [HttpDelete]
        public Task Delete(int id)
        {
            return _packageService.DeletePackage(id);
        }
    }
}
