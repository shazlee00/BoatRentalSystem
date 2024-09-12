using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.BoatBooking.Command.Add
{
    using AutoMapper;
    using BoatRentalSystem.Application.BoatBooking.ViewModels;
  
    using BoatRentalSystem.Core.Entities;
    using BoatRentalSystem.Core.Interfaces;

    public class AddBoatBookingCommand : ICommand<BoatBookingDto>
    {
        public AddBoatBookingDto Data { get; set; }
        public AddBoatBookingCommand(AddBoatBookingDto data)
        {
            Data = data;
        }
    }

    public class AddBoatBookingCommandHandler : ICommandHandler<AddBoatBookingCommand, BoatBookingDto>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IMapper _mapper;

        public AddBoatBookingCommandHandler(IBoatBookingRepository boatBookingRepository, IMapper mapper)
        {
            _boatBookingRepository = boatBookingRepository;
            _mapper = mapper;
        }

        public async Task<BoatBookingDto> Handle(AddBoatBookingCommand request, CancellationToken cancellationToken)
        {

            if (request.Data.BookingAdditions.Count == 1 && request.Data.BookingAdditions[0].AdditionId == 0)
            {
                request.Data.BookingAdditions = null;
            }

            var boatBooking = _mapper.Map<BoatBooking>(request.Data);
            boatBooking.Status = BoatBookingStatus.Pending;
            boatBooking.CreatedAt = DateTime.Now;
            await _boatBookingRepository.AddAsync(boatBooking);
            
            return _mapper.Map<BoatBookingDto>(boatBooking);
        }
    }
}
