using BoatRentalSystem.Application.Payment.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Payment.Command
{
    public class CancelBoatBookingCommand:ICommand<CancellationDto>
    {
        public int BookingId { get; set; }

        public CancelBoatBookingCommand(int bookingId)
        {
            BookingId = bookingId;
        }
    }

    public class CancleBoatBookingCommandHandler : ICommandHandler<CancelBoatBookingCommand, CancellationDto>
    {
        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly ICancellationRepository _cancellationRepository;


        public CancleBoatBookingCommandHandler(IBoatBookingRepository boatBookingRepository, IPaymentTransactionRepository paymentTransactionRepository, ICancellationRepository cancellationRepository)
        {
            _boatBookingRepository = boatBookingRepository;
            _paymentTransactionRepository = paymentTransactionRepository;
            _cancellationRepository = cancellationRepository;
        }


        public async Task<CancellationDto> Handle(CancelBoatBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _boatBookingRepository.GetBoatBookingByIdAsync(request.BookingId);

            if (booking == null)
            {
                throw new Exception("booking not found");
            }


            if (booking.Status == BoatBookingStatus.Pending )
            {
                booking.Status = BoatBookingStatus.Canceled;
            }

            if (booking.Status == BoatBookingStatus.Confirmed)
            {
                var customerId = booking.CustomerId;
                var ownerId = booking.Boat.OwnerId;
                var paymentStatus = await _paymentTransactionRepository.ProcessRefundTransactionAsync(customerId, ownerId, booking.TotalPrice);
                if (paymentStatus)
                {
                    booking.Status = BoatBookingStatus.Canceled;
                }
                else
                {
                    booking.Status = BoatBookingStatus.Pending;
                }
            }


            var cancellation = new Cancellation
            {
                BoatBookingId = request.BookingId,
                CustomerId = booking.CustomerId,
                RefundAmount = booking.Status == BoatBookingStatus.Canceled ? booking.TotalPrice : 0,

            };

            await _cancellationRepository.AddAsync(cancellation);

            return new CancellationDto
            {
                BoatBookingId = request.BookingId,
                CustomerId = booking.CustomerId,
                RefundAmount = cancellation.RefundAmount
            };


        }
    }





}
