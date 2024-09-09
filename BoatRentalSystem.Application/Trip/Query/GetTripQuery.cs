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
    public class GetTripQuery:IQuery<TripDto>
    {
        public int TripId { get; set; }
        public GetTripQuery(int tripId)
        {
            TripId = tripId;
        }
    }

    public class GetTripQueryHandler:IQueryHandler<GetTripQuery,TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;


        public GetTripQueryHandler( ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<TripDto> Handle(GetTripQuery request, CancellationToken cancellationToken)
        {
           
            var trip = await _tripRepository.GetByIdAsync(request.TripId);
            return _mapper.Map<TripDto>(trip);

        }
    }






}
