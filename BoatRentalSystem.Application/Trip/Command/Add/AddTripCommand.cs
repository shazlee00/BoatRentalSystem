using AutoMapper;
using BoatRentalSystem.Application.Trip.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Trip.Command.Add
{
    public class AddTripCommand:ICommand<TripDto>
    {
        public AddTripDto Trip { get; set; }

        public AddTripCommand(AddTripDto trip)
        {
            Trip = trip;
        }

    }


    public class AddTripCommandHandler : ICommandHandler<AddTripCommand, TripDto>
    {
        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public AddTripCommandHandler(ITripRepository tripRepository, IMapper mapper)
        {
            this._tripRepository = tripRepository;
            _mapper = mapper;
        }


        public async Task<TripDto> Handle(AddTripCommand request, CancellationToken cancellationToken)
        {
            var trip = _mapper.Map<Core.Entities.Trip>(request.Trip);
                trip.Status=TripStatus.Pending;

            await _tripRepository.AddAsync(trip);
            
            
                return _mapper.Map<TripDto>(trip);
            
           

        }
    }




}
