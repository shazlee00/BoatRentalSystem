using AutoMapper;
using BoatRentalSystem.Application.City.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.City.Query
{
    public class GetCityQuery : IQuery<CityDto>
    {
        public int CityId { get;}

        public GetCityQuery(int cityId)
        {
            CityId = cityId;
        }
    }


    public class GetCityQueryHandler : IQueryHandler<GetCityQuery, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetByIdAsync(request.CityId);
            var cityViewModel = _mapper.Map<CityDto>(city);

            return cityViewModel;
        }
    }
}
