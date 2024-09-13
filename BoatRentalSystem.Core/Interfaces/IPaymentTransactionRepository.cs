using BoatRentalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Core.Interfaces
{
    public interface IPaymentTransactionRepository
    {
        Task<bool> ProcessPaymentTransactionAsync(int customerId, int ownerId, double amount);
        Task<bool> ProcessRefundTransactionAsync(int customerId, int ownerId, double amount);












    }
}
