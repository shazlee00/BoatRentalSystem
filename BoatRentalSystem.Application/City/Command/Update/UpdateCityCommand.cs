using AutoMapper;
using BoatRentalSystem.Application.City.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.City.Command.Update
{

    public class UpdateCityCommand : ICommand<CityDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateCityCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


    public class UpdateCityHandler : ICommandHandler<UpdateCityCommand, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityDto> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(request.Id);
            if (city != null)
            {
                city.Name = request.Name;
                await _cityRepository.UpdateAsync(city.Id, city);
                return _mapper.Map<CityDto>(city);
            }
            throw new KeyNotFoundException("City not found");
        }
    }
}
