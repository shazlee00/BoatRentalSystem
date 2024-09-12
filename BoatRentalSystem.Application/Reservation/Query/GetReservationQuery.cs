using AutoMapper;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Reservation.Query
{
    public class GetReservationQuery : IQuery<ReservationDto>
    {
        public int Id { get; set; }

        public GetReservationQuery(int id)
        {
            Id = id;
        }
    }

    public class GetReservationQueryHandler : IQueryHandler<GetReservationQuery, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }


        public async Task<ReservationDto> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var Reservations = await _reservationRepository.GetReservationByIdAsync(request.Id);

            var ReservationsViewModel = _mapper.Map<ReservationDto>(Reservations);

            return ReservationsViewModel;

        }
    }
}
