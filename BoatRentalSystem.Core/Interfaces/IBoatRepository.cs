using BoatRentalSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Interfaces
{
    public interface IBoatRepository : IBaseRepository<Boat>
    {

        Task<IEnumerable<Boat>> GetAvailbeAsync();
    }
}
