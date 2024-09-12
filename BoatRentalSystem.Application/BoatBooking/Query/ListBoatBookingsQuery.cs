using AutoMapper;
using BoatRentalSystem.Application.BoatBooking.ViewModels;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.BoatBooking.Query
{
    public class ListBoatBookingsQuery : IQuery<IEnumerable<BoatBookingDto>>
    {
    }

    public class ListBoatBookingsQueryHandler : IQueryHandler<ListBoatBookingsQuery, IEnumerable<BoatBookingDto>>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IMapper _mapper;

        public ListBoatBookingsQueryHandler(IBoatBookingRepository boatBookingRepository, IMapper mapper)
        {
            _boatBookingRepository = boatBookingRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BoatBookingDto>> Handle(ListBoatBookingsQuery request, CancellationToken cancellationToken)
        {
            var BoatBookings = await _boatBookingRepository.GetAllBoatBookingsAsync();

            var BoatBookingsViewModel = _mapper.Map<IEnumerable<BoatBookingDto>>(BoatBookings);

            return BoatBookingsViewModel;

        }
    }



    public class ListCustomerBoatBookingQuery : IQuery<IEnumerable<BoatBookingDto>>
    {
        public int CustomerId { get; set; }

        public ListCustomerBoatBookingQuery(int customerId)
        {
            CustomerId = customerId;
        }
    }

    public class ListCustomerBoatBookingQueryHandler : IQueryHandler<ListCustomerBoatBookingQuery, IEnumerable<BoatBookingDto>>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IMapper _mapper;

        public ListCustomerBoatBookingQueryHandler(IBoatBookingRepository boatBookingRepository, IMapper mapper)
        {
            _boatBookingRepository = boatBookingRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BoatBookingDto>> Handle(ListCustomerBoatBookingQuery request, CancellationToken cancellationToken)
        {
            var BoatBookings = await _boatBookingRepository.GetAllBoatBookingsAsync();

            BoatBookings = BoatBookings.Where(x => x.CustomerId == request.CustomerId).ToList();

            var BoatBookingsViewModel = _mapper.Map<IEnumerable<BoatBookingDto>>(BoatBookings);

            return BoatBookingsViewModel;

        }
    }


    public class ListOwnerBoatBookingQuery : IQuery<IEnumerable<BoatBookingDto>>
    {
        public int OwnerId { get; set; }

        public ListOwnerBoatBookingQuery(int ownerId)
        {
            OwnerId = ownerId;
        }
    }

    public class ListOwnerBoatBookingQueryQueryHandler : IQueryHandler<ListOwnerBoatBookingQuery, IEnumerable<BoatBookingDto>>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IMapper _mapper;

        public ListOwnerBoatBookingQueryQueryHandler(IBoatBookingRepository boatBookingRepository, IMapper mapper)
        {
            _boatBookingRepository = boatBookingRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<BoatBookingDto>> Handle(ListOwnerBoatBookingQuery request, CancellationToken cancellationToken)
        {
            var BoatBookings = await _boatBookingRepository.GetAllBoatBookingsAsync();

            BoatBookings = BoatBookings.Where(x =>x.Boat.OwnerId == request.OwnerId ).ToList();

            var BoatBookingsViewModel = _mapper.Map<IEnumerable<BoatBookingDto>>(BoatBookings);

            return BoatBookingsViewModel;

        }
    }























}
