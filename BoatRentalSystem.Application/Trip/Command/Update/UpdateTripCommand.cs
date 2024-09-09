using AutoMapper;
using BoatRentalSystem.Application.Trip.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Trip.Command.Update
{
    public class UpdateTripCommand:ICommand<TripDto>
    {
        public UpdateTripDto Trip { get; set; }
        public UpdateTripCommand( UpdateTripDto updateTripDto)
        {
            Trip = updateTripDto;
        }
    
    }

    public class UpdateTripCommandHandler : ICommandHandler<UpdateTripCommand, TripDto>
    {

        private readonly ITripRepository _tripRepository;
        private readonly IMapper _mapper;

        public UpdateTripCommandHandler(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }


        public async Task<TripDto> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
        {
            var trip= await _tripRepository.GetByIdAsync(request.Trip.TripId);
            if (trip == null)
            {
                throw new Exception("Trip not found");
            }

            if(request.Trip.BoatId==null)
            {
               request.Trip.BoatId = trip.BoatId;
            }

            if(request.Trip.OwnerId==null)
            {
              request.Trip.OwnerId = trip.OwnerId;
            }

            if(request.Trip.StartedAt==null)
            {
                request.Trip.StartedAt = trip.StartedAt;
            }


            _mapper.Map(request.Trip, trip);  
            await _tripRepository.UpdateAsync(request.Trip.TripId,trip);
            return _mapper.Map<TripDto>(trip);
        }
    }



}
