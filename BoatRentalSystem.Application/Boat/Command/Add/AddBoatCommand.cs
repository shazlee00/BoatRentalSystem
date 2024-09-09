using AutoMapper;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Boat.Command.Add
{

    public class AddBoatCommand : ICommand<BoatDto>
    {
        public AddBoatDto Boat { get; set; }
        public AddBoatCommand(AddBoatDto boat)
        {
            Boat = boat;
        }
    }


    public class AddBoatHandler : ICommandHandler<AddBoatCommand, BoatDto>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public AddBoatHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }
        public async Task<BoatDto> Handle(AddBoatCommand request, CancellationToken cancellationToken)
        {
            // Use AutoMapper to map AddBoatDto to Boat entity
            var boat = _mapper.Map<Core.Entities.Boat>(request.Boat);

            boat.Status = BoatStatus.Pending;

            // Add the new boat to the repository
            await _boatRepository.AddAsync(boat);


            // Map the Boat entity back to a BoatDto to return
            return _mapper.Map<BoatDto>(boat);
        }
    }
}
