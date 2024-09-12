using AutoMapper;
using BoatRentalSystem.Application.BoatBooking.ViewModels;
using BoatRentalSystem.Application.Reservation.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.BoatBooking.Command.Update
{
    public class UpdateBoatBookingCommand : ICommand<BoatBookingDto>
    {
        public UpdateBoatBookingDto Data { get; set; }
        public UpdateBoatBookingCommand(UpdateBoatBookingDto data)
        {
            Data = data;
        }
    }


    public class UpdateBoatBookingCommandHandler : ICommandHandler<UpdateBoatBookingCommand, BoatBookingDto>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IMapper _mapper;

        public UpdateBoatBookingCommandHandler(IBoatBookingRepository bootBookingRepository, IMapper mapper)
        {
            _boatBookingRepository = bootBookingRepository;
            _mapper = mapper;
        }

        public async Task<BoatBookingDto> Handle(UpdateBoatBookingCommand request, CancellationToken cancellationToken)
        {

            var boatBooking = await _boatBookingRepository.GetByIdAsync(request.Data.BoatBookingId);
            if (boatBooking == null)
            {
                throw new Exception("BoatBooking not found");
            }

            boatBooking.UpdatedAt = DateTime.Now;

            _mapper.Map<Core.Entities.BoatBooking>(request.Data);
            await _boatBookingRepository.UpdateAsync(request.Data.BoatBookingId, boatBooking);
            return _mapper.Map<BoatBookingDto>(boatBooking);
        }


    }

    public class UpdateBoatBookingStatusCommand : ICommand<BoatBookingDto>
    {
        public int BoatBookingId { get; set; }
        public BoatBookingStatus Status { get; set; }
        public UpdateBoatBookingStatusCommand(BoatBookingStatus status, int reservationId)
        {
            BoatBookingId = reservationId;
            Status = status;
        }
    }


    public class UpdateBoatBookingStatusCommandHandler : ICommandHandler<UpdateBoatBookingStatusCommand, BoatBookingDto>
    {
        private readonly IBoatBookingRepository _BoatBookingRepository;
        private readonly IMapper _mapper;

        public UpdateBoatBookingStatusCommandHandler(IBoatBookingRepository boatBookingRepository, IMapper mapper)
        {
            _BoatBookingRepository = boatBookingRepository;
            _mapper = mapper;
        }

        public async Task<BoatBookingDto> Handle(UpdateBoatBookingStatusCommand request, CancellationToken cancellationToken)
        {

            var boatBooking = await _BoatBookingRepository.GetByIdAsync(request.BoatBookingId);
            if (boatBooking == null)
            {
                throw new Exception("BoatBooking not found");
            }

            boatBooking.Status = request.Status;
            await _BoatBookingRepository.UpdateAsync(request.BoatBookingId, boatBooking);

            return _mapper.Map<BoatBookingDto>(boatBooking);
        }


    }








}
