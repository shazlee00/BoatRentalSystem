using AutoMapper;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Reservation.Command.Add
{
    using BoatRentalSystem.Core.Entities;
    public class AddReservationCommand:ICommand<ReservationDto>
    {
        public AddReservationDto Data { get; set; }
        public AddReservationCommand(AddReservationDto data)
        {
            Data = data;
        }
    }

    public class AddReservationCommandHandler : ICommandHandler<AddReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public AddReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {

            if (request.Data.ReservationAdditions.Count==1&&request.Data.ReservationAdditions[0].AdditionId==0)
            {
               request.Data.ReservationAdditions=null;
            }

            var reservation = _mapper.Map<Reservation>(request.Data);
            reservation.Status = ReservationStatus.Pending;
            await _reservationRepository.AddAsync(reservation);
            return _mapper.Map<ReservationDto>(reservation);
        }
    }







}
