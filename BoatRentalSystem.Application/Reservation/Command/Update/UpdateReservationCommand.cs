using AutoMapper;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Reservation.Command.Update
{
    public class UpdateReservationCommand:ICommand<ReservationDto>
    {
        public UpdateReservationDto Data { get; set; }
        public UpdateReservationCommand(UpdateReservationDto data)
        {
            Data = data;
        }
    }


    public class UpdateReservationCommandHandler : ICommandHandler<UpdateReservationCommand, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {

            var reservation = await _reservationRepository.GetByIdAsync(request.Data.ReservationId);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

           _mapper.Map<Core.Entities.Reservation>(request.Data);
            await _reservationRepository.UpdateAsync(request.Data.ReservationId,reservation);
            return _mapper.Map<ReservationDto>(reservation);
        }
    
    
    }

    public class UpdateReservationStatusCommand : ICommand<ReservationDto>
    {
        public int ReservationId { get; set; }
        public ReservationStatus Status { get; set; }
        public UpdateReservationStatusCommand(ReservationStatus status ,int reservationId)
        {
            ReservationId = reservationId;
             Status=status;
        }
    }


    public class UpdateReservationStatusCommandCommandHandler : ICommandHandler<UpdateReservationStatusCommand, ReservationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public UpdateReservationStatusCommandCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<ReservationDto> Handle(UpdateReservationStatusCommand request, CancellationToken cancellationToken)
        {

            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            reservation.Status = request.Status;
            await _reservationRepository.UpdateAsync(request.ReservationId, reservation);

            return _mapper.Map<ReservationDto>(reservation);
        }


    }


}
