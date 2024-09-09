using AutoMapper;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Boat.Query
{
    public class GetBoatQuery : IQuery<BoatDto>
    {
        public int BoatId { get;}

        public GetBoatQuery(int boatId)
        {
            BoatId = boatId;
        }
    }


    public class GetBoatQueryHandler : IQueryHandler<GetBoatQuery, BoatDto>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public GetBoatQueryHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }

        public async Task<BoatDto> Handle(GetBoatQuery request, CancellationToken cancellationToken)
        {
            var boat = await _boatRepository.GetByIdAsync(request.BoatId);
            var boatViewModel = _mapper.Map<BoatDto>(boat);

            return boatViewModel;
        }
    }
}
