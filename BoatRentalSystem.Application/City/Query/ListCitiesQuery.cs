using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoatRentalSystem.Application.City.ViewModels;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;

namespace BoatRentalSystem.Application.City.Query
{
    public class ListCitiesQuery:IQuery<IEnumerable<CityDto>>
    {
    }


    public class ListCitiesQueryHandler : IQueryHandler<ListCitiesQuery, IEnumerable<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public ListCitiesQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> Handle(ListCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities=await _cityRepository.GetAllAsync();
            var cityViewModel = _mapper.Map<IEnumerable<CityDto>>(cities);
            
            return cityViewModel;
        }
    }




}
