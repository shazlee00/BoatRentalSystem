using AutoMapper;
using BoatRentalSystem.Application.Trip.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Trip.Query
{
    public class ListTripsQuery:IQuery<IEnumerable<TripDto>>
    {
    }
    public class ListTripsQueryHandler : IQueryHandler<ListTripsQuery, IEnumerable<TripDto>>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public ListTripsQueryHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TripDto>> Handle(ListTripsQuery request, CancellationToken cancellationToken)
        {
            var trips = await _tripRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TripDto>>(trips);

        }
    }
}
