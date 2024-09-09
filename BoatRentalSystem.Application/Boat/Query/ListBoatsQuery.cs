using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Application.Services;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;

namespace BoatRentalSystem.Application.Boat.Query
{
    public class ListBoatsQuery:IQuery<IEnumerable<BoatDto>>
    {
    }
    

    public class ListBoatsQueryHandler : IQueryHandler<ListBoatsQuery, IEnumerable<BoatDto>>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public ListBoatsQueryHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoatDto>> Handle(ListBoatsQuery request, CancellationToken cancellationToken)
        {
            var boats=await _boatRepository.GetAllAsync();
            var boatViewModel = _mapper.Map<IEnumerable<BoatDto>>(boats);
            
            return boatViewModel;
        }
    }

    public class ListAvailbeBoatsQuery : IQuery<IEnumerable<BoatDto>>
    {
    }


    public class ListAvailbeBoatsQueryHandler : IQueryHandler<ListAvailbeBoatsQuery, IEnumerable<BoatDto>>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public ListAvailbeBoatsQueryHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoatDto>> Handle(ListAvailbeBoatsQuery request, CancellationToken cancellationToken)
        {
            var boats = await _boatRepository.GetAvailbeAsync();
            var boatViewModel = _mapper.Map<IEnumerable<BoatDto>>(boats);

            return boatViewModel;
        }
    }

    public class ListOwnerBoatsQuery : IQuery<IEnumerable<BoatDto>>
    {

        public int OwnerId { get; set; }

        public ListOwnerBoatsQuery(int ownerId)
        {
            OwnerId = ownerId;
        }
    }


    public class ListOwnerBoatsQueryHandler : IQueryHandler<ListOwnerBoatsQuery, IEnumerable<BoatDto>>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public ListOwnerBoatsQueryHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoatDto>> Handle(ListOwnerBoatsQuery request, CancellationToken cancellationToken)
        {
            var boats = await _boatRepository.GetAllAsync();
            var ownerBoats=boats.Where(x=>x.OwnerId==request.OwnerId);
            var boatViewModel = _mapper.Map<IEnumerable<BoatDto>>(ownerBoats);

            return boatViewModel;
        }
    }




}
