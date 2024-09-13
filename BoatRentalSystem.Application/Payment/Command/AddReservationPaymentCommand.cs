using BoatRentalSystem.Application.Payment.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRentalSystem.Application.Payment.Command
{
    public class AddReservationPaymentCommand : ICommand<PaymentDto>
    {
        public int ReservationId { get; set; }
        public AddReservationPaymentCommand(int reservationId)
        {
            ReservationId = reservationId;
        }
    }

    public class AddReservationPaymentCommandHandler : ICommandHandler<AddReservationPaymentCommand, PaymentDto>
    {

        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationPaymentRepository _reservationPaymentRepository;
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly IOwnerRepository _ownerRepository;

        public AddReservationPaymentCommandHandler(IReservationRepository reservationRepository, IReservationPaymentRepository reservationPaymentRepository, IPaymentTransactionRepository paymentTransactionRepository, IOwnerRepository ownerRepository)
        {
            _reservationRepository = reservationRepository;
            _reservationPaymentRepository = reservationPaymentRepository;
            _paymentTransactionRepository = paymentTransactionRepository;
            _ownerRepository = ownerRepository;
        }


        public async Task<PaymentDto> Handle(AddReservationPaymentCommand request, CancellationToken cancellationToken)
        {

            var reservation = await _reservationRepository.GetReservationByIdAsync(request.ReservationId);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            var customerId = reservation.CustomerId;
            var ownerId = reservation.Trip.OwnerId;

            if (reservation.Status == ReservationStatus.Canceled)
            {

                throw new Exception("Reservation Canceled");
            }

            

            var paymentStatus = await _paymentTransactionRepository.ProcessPaymentTransactionAsync(customerId, ownerId, reservation.TotalPrice);

            if(paymentStatus)
            {
                reservation.Status = ReservationStatus.Confirmed;
            }
            var payment = new ReservationPayment
            {
                CustomerId = customerId,
                OwnerId = ownerId,
                ReservationId = request.ReservationId,
                PaymentStatus = paymentStatus,
                Amount = reservation.TotalPrice
            };

            await _reservationPaymentRepository.AddAsync(payment);
            var owner = await _ownerRepository.GetByIdAsync(ownerId);


            return new PaymentDto
            {
                CustomerId = customerId,
                CustomerName = reservation.Customer.FirstName + " " + reservation.Customer.LastName,
                OwnerId = ownerId,
                OwnerName = owner.BusinessName,
                TripId = reservation.TripId,
                TripName = reservation.Trip.Name,
                Amount = reservation.TotalPrice,
                Status = paymentStatus.ToString(),
                PaymentDate = DateTime.Now
            };

        }



    }


}




