using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatRentalSystem.Application.Payment.ViewModels;
using BoatRentalSystem.Core.Entities;
using BoatRentalSystem.Core.Interfaces;

namespace BoatRentalSystem.Application.Payment.Command
{
    public class CancelReservationCommand:ICommand<CancellationDto>
    {
        public int ReservationId { get; set; }

        public CancelReservationCommand(int reservationId)
        {
            ReservationId = reservationId;
        }
    }


    public class CancleReservationCommandHandler:ICommandHandler<CancelReservationCommand,CancellationDto>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationPaymentRepository _reservationPaymentRepository;
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly ICancellationRepository _cancellationRepository;

        public CancleReservationCommandHandler(ICancellationRepository cancellationRepository, IReservationRepository reservationRepository, IReservationPaymentRepository reservationPaymentRepository, IPaymentTransactionRepository paymentTransactionRepository)
        {
            _cancellationRepository = cancellationRepository;
            _reservationRepository = reservationRepository;
            _reservationPaymentRepository = reservationPaymentRepository;
            _paymentTransactionRepository = paymentTransactionRepository;

        }

        public async Task<CancellationDto> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
          var reservation = await _reservationRepository.GetReservationByIdAsync(request.ReservationId);

            if(reservation == null)
            {
                throw new Exception("Reservation not found");
            }


            if (reservation.Status == ReservationStatus.Pending && reservation.Trip.CancellationDeadline > DateTime.Now)
            {
                reservation.Status = ReservationStatus.Canceled;
            }

            if(reservation.Status == ReservationStatus.Confirmed)
            {
                var customerId = reservation.CustomerId;
                var ownerId = reservation.Trip.OwnerId;
                var paymentStatus = await _paymentTransactionRepository.ProcessRefundTransactionAsync(customerId, ownerId, reservation.TotalPrice);
                if (paymentStatus)
                {
                    reservation.Status = ReservationStatus.Canceled;
                }
                else
                {
                    reservation.Status = ReservationStatus.Pending;
                }
            }


            var cancellation = new Cancellation
            {
                ReservationId = request.ReservationId,
                CustomerId = reservation.CustomerId,
                RefundAmount = reservation.Status == ReservationStatus.Canceled ? reservation.TotalPrice : 0,

            };

            await _cancellationRepository.AddAsync(cancellation);
            
return new CancellationDto
            {
                ReservationId = request.ReservationId,
                CustomerId = reservation.CustomerId,
                RefundAmount = cancellation.RefundAmount
            };


               
            }









        
    }









}
