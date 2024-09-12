using AutoMapper;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Reservation.Query
{
    public class ListReservationsQuery: IQuery<IEnumerable<ReservationDto>>
    {
    }

    public class ListReservationsQueryHandler : IQueryHandler<ListReservationsQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ListReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

   
        public async Task<IEnumerable<ReservationDto>> Handle(ListReservationsQuery request, CancellationToken cancellationToken)
        {
            var Reservations = await _reservationRepository.GetAllReservationAsync();

            var ReservationsViewModel = _mapper.Map<IEnumerable<ReservationDto>>(Reservations);

            return ReservationsViewModel;

        }
    }
       public class ListCustomerReservationQuery : IQuery<IEnumerable<ReservationDto>>
        {
            public int CustomerId { get; set; }

            public ListCustomerReservationQuery(int customerId)
            {
                CustomerId = customerId;
            }
        }

    public class ListCustomerReservationQueryHandler : IQueryHandler<ListCustomerReservationQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ListCustomerReservationQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

   
        public async Task<IEnumerable<ReservationDto>> Handle(ListCustomerReservationQuery request, CancellationToken cancellationToken)
        {
            var Reservations = await _reservationRepository.GetAllReservationAsync();

            Reservations = Reservations.Where(x => x.CustomerId == request.CustomerId).ToList();

            var ReservationsViewModel = _mapper.Map<IEnumerable<ReservationDto>>(Reservations);

            return ReservationsViewModel;

        }
    }
      public class ListOwnerReservationQuery : IQuery<IEnumerable<ReservationDto>>
        {
            public int OnwerId { get; set; }

            public ListOwnerReservationQuery(int ownerId)
            {
            OnwerId = ownerId;
            }
        }

    public class ListOwnerReservationQueryHandler : IQueryHandler<ListOwnerReservationQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ListOwnerReservationQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

   
        public async Task<IEnumerable<ReservationDto>> Handle(ListOwnerReservationQuery request, CancellationToken cancellationToken)
        {
            var Reservations = await _reservationRepository.GetAllReservationAsync();

            Reservations = Reservations.Where(x => x.Trip.OwnerId == request.OnwerId).ToList();

            var ReservationsViewModel = _mapper.Map<IEnumerable<ReservationDto>>(Reservations);

            return ReservationsViewModel;

        }
    }





}
