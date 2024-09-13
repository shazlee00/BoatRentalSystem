using BoatRentalSystem.Application.Payment.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Payment.Command
{
    public class AddBoatBookingPaymentCommand:ICommand<PaymentDto>
    {
        public int BookingId { get; set; }
        public AddBoatBookingPaymentCommand(int bookingId ) 
        {
            BookingId = bookingId;
        }
    }


    public class AddBoatBookingPaymentCommandHandler : ICommandHandler<AddBoatBookingPaymentCommand, PaymentDto>
    {

        private readonly IBoatBookingRepository _boatBookingRepository;
        private readonly IBookingPaymentRepository _bookingPaymentRepository;
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly IOwnerRepository _ownerRepository;


        public AddBoatBookingPaymentCommandHandler(IBoatBookingRepository bookingrepository, IBookingPaymentRepository bookingPaymentRepository, IPaymentTransactionRepository paymentTransactionRepository,IOwnerRepository ownerRepository )
        {
            _boatBookingRepository = bookingrepository;
            _bookingPaymentRepository = bookingPaymentRepository;
            _paymentTransactionRepository = paymentTransactionRepository;

            _ownerRepository = ownerRepository;
        }



        public async Task<PaymentDto> Handle(AddBoatBookingPaymentCommand request, CancellationToken cancellationToken)
        {
            var booking = await _boatBookingRepository.GetBoatBookingByIdAsync(request.BookingId);

            if (booking == null)
            {
                return null;
            }

            var customerId = booking.CustomerId;
            var ownerId = booking.Boat.OwnerId;
            
            if (booking.Status == BoatBookingStatus.Canceled)
            {

                throw new Exception("booking Canceled");
            }



            var paymentStatus = await _paymentTransactionRepository.ProcessPaymentTransactionAsync(customerId, ownerId, booking.TotalPrice);

            if (paymentStatus)
            {
                booking.Status = BoatBookingStatus.Confirmed;
            }
            var payment = new BookingPayment
            {
                CustomerId = customerId,
                OwnerId = ownerId,
                BookingId = request.BookingId,
                PaymentStatus = paymentStatus,
                Amount = booking.TotalPrice
            };

            await _bookingPaymentRepository.AddAsync(payment);

            var owner= await _ownerRepository.GetByIdAsync(ownerId);



            return new PaymentDto
            {
                CustomerId = customerId,
                CustomerName = booking.Customer.FirstName + " " + booking.Customer.LastName,
                OwnerId = ownerId,
                OwnerName=owner.BusinessName,
                Amount = booking.TotalPrice,
                BookingId=request.BookingId,
                Status = paymentStatus.ToString(),
                PaymentDate = DateTime.Now
            };
        }
    }









}
