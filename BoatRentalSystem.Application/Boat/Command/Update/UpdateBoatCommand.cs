using AutoMapper;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Boat.Command.Update
{
    public class UpdateBoatCommand:ICommand<BoatDto>
    {

        public UpdateBoatDto UpdateBoatDto { get; set; }
        public int AuthOwnerId { get; set; }

        public UpdateBoatCommand(UpdateBoatDto updateBoatDto, int ownerId)
        {
            UpdateBoatDto = updateBoatDto;
            AuthOwnerId = ownerId;
        }
    }

    public class UpdateBoatCommandHandler : ICommandHandler<UpdateBoatCommand, BoatDto>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public UpdateBoatCommandHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }
        public async Task<BoatDto> Handle(UpdateBoatCommand request, CancellationToken cancellationToken)
        {
           var boat=await _boatRepository.GetByIdAsync(request.UpdateBoatDto.BoatId);
           if(boat==null)
            {
                return null;
            }

           if(boat.OwnerId!=request.AuthOwnerId)
            {
                return null;
            }
           
            _mapper.Map(request.UpdateBoatDto, boat);
            await _boatRepository.UpdateAsync(boat.BoatId, boat);
            return _mapper.Map<BoatDto>(boat);
        }
    }





}
