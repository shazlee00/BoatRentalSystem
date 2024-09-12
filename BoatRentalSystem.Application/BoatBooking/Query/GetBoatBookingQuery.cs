using AutoMapper;
using BoatRentalSystem.Application.BoatBooking.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.BoatBooking.Query
{
    public class GetBoatBookingQuery : IQuery<BoatBookingDto>
    {
        public int Id { get; set; }

        public GetBoatBookingQuery(int id)
        {
            Id = id;
        }
    }

    public class GetBoatBookingQueryHandler : IQueryHandler<GetBoatBookingQuery, BoatBookingDto>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IMapper _mapper;

        public GetBoatBookingQueryHandler(IBoatBookingRepository boatBookingRepository, IMapper mapper)
        {
            _boatBookingRepository = boatBookingRepository;
            _mapper = mapper;
        }


        public async Task<BoatBookingDto> Handle(GetBoatBookingQuery request, CancellationToken cancellationToken)
        {
            var BoatBookings = await _boatBookingRepository.GetBoatBookingByIdAsync(request.Id);

            var BoatBookingsViewModel = _mapper.Map<BoatBookingDto>(BoatBookings);

            return BoatBookingsViewModel;

        }
    }
}
