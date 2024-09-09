using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Interfaces
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<Owner> GetByUserIdAsync(string userId);
    }
}
