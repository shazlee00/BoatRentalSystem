using AutoMapper;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Boat.Command.Update
{
    public class BoatStatusResult
    {
        public string Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
    public class VerifyBoatCommand : ICommand<BoatStatusResult>
    {
        public int BoatId { get; set; }
        public BoatStatus Status { get; set; }

    }



    public class VerifyBoatHandler : ICommandHandler<VerifyBoatCommand, BoatStatusResult>
    {
        private readonly IBoatRepository _boatRepository;
        private readonly IMapper _mapper;

        public VerifyBoatHandler(IBoatRepository boatRepository, IMapper mapper)
        {
            _boatRepository = boatRepository;
            _mapper = mapper;
        }
        public async Task<BoatStatusResult> Handle(VerifyBoatCommand request, CancellationToken cancellationToken)
        {
            var boatId=request.BoatId;

            var boat=await _boatRepository.GetByIdAsync(boatId);

            if(boat==null)
            {
                return new BoatStatusResult
                {
                    Status = "Failed",
                    Message = "Boat not found"
                };
            }

            boat.Status=request.Status;
            boat.UpdatedAt=DateTime.Now;

            await _boatRepository.UpdateAsync(boatId, boat);

            return new BoatStatusResult
            {
                Status = boat.Status.ToString(),
                Message = "Boat status updated successfully"
            };

            

        }
    }



}
