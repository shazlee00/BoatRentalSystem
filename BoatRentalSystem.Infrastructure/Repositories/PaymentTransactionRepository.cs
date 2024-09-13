using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Infrastructure.Repositories
{
    public class PaymentTransactionRepository:IPaymentTransactionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOwnerRepository _ownerRepository;
        public PaymentTransactionRepository(ApplicationDbContext dbContext, ICustomerRepository customerRepository, IOwnerRepository ownerRepository)
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<bool> ProcessPaymentTransactionAsync(int customerId, int ownerId, double amount)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            var owner = await _ownerRepository.GetByIdAsync(ownerId);

           
            if (customer.WalletBalance < amount)
            {
                return false; 
            }

            
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
              
                customer.WalletBalance -= amount;
                await _customerRepository.UpdateAsync(customerId,customer);

               
                owner.WalletBalance += amount;
                await _ownerRepository.UpdateAsync(ownerId,owner);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                // Rollback if something goes wrong
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> ProcessRefundTransactionAsync(int customerId, int ownerId, double amount)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            var owner = await _ownerRepository.GetByIdAsync(ownerId);


            if (owner.WalletBalance < amount)
            {
                return false;
            }


            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {

                owner.WalletBalance -= amount;
                await _ownerRepository.UpdateAsync(ownerId, owner);



                customer.WalletBalance += amount;
                await _customerRepository.UpdateAsync(customerId, customer);
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                // Rollback if something goes wrong
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
