using AutoMapper;
using BoatRentalSystem.Application.City.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.City.Command.Add
{

    public class AddCityCommand : ICommand<CityDto>
    {
        public string Name { get; set; }
        public AddCityCommand(string name)
        {
            Name = name;
        }
    }


    public class AddCityHandler : ICommandHandler<AddCityCommand, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public AddCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityDto> Handle(AddCityCommand request, CancellationToken cancellationToken)
        {
        var city = new Core.Entities.City
            {
                Name = request.Name
            };
            await _cityRepository.AddAsync(city);
            return _mapper.Map<CityDto>(city);
        }
    }
}
