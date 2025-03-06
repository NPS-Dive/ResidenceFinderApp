

namespace ResFin.Domain.Residences.Events.Reservations;

public sealed class Reservation : BaseEntity
    {

    #region Constructor

    private Reservation (
        Guid id,
        Guid residenceId,
        Guid userId,
        Duration duration,
        Money rentingPrice,
        Money cleansingFee,
        Money amenitiesUpCharge,
        Money discount,
        Money totalPrice,
        ReservationStatus status,
        DateTime createdUtc
       )
        : base(id)
        {
        ResidenceId = residenceId;
        UserId = userId;
        Duration = duration;
        RentingPrice = rentingPrice;
        CleansingFee = cleansingFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        Discount = discount;
        TotalPrice = totalPrice;
        Status = status;
        CreatedUTC = createdUtc;
        }

        private Reservation()
        {
            
        }

    #endregion

    public Guid ResidenceId { get; private set; }
    public Guid UserId { get; private set; }
    public Duration Duration { get; private set; }
    public Money RentingPrice { get; private set; }
    public Money CleansingFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money Discount { get; private set; }
    public Money TotalPrice { get; private set; }
    public ReservationStatus Status { get; private set; }
    public DateTime CreatedUTC { get; private set; }
    public DateTime? ConfirmedUTC { get; private set; }
    public DateTime? RejectedUTC { get; private set; }
    public DateTime? CompletedUTC { get; private set; }
    public DateTime? FinishedUTC { get; private set; }
    public DateTime? CancelledUTC { get; private set; }



    public static Reservation Create (
        Residence residence,
        Guid userId,
        Duration duration,
        DateTime utcNow,
       PricingService pricingService
        )
        {
        var pricingDetails = pricingService.BillCalculator(residence, duration);

        var newReservation = new Reservation(
            Guid.NewGuid(),
            residence.Id,
            userId,
            duration,
            pricingDetails.RowPriceForDuration,
            pricingDetails.CleaningFee,
            pricingDetails.AmenitiesUpCharge,
            pricingDetails.Discount,
            pricingDetails.FinalPrice,
            ReservationStatus.Reserved,
            utcNow
            );

        newReservation.RaiseDomainEvent(new ReservationReservedDomainEvent(newReservation.Id));

        residence.LastBookedUTC = utcNow;

        return newReservation;
        }

    public Result Confirm ( DateTime utcNow )
        {
        if (Status is not ReservationStatus.Reserved)
            {
            return Result.Failure(ReservationErrors.NotReserved);
            }

        Status = ReservationStatus.Confirmed;
        ConfirmedUTC = utcNow;
        RaiseDomainEvent(new ReservationConfirmedDomainEvent(Id));

        return Result.Success();
        }


    public Result Reject ( DateTime utcNow )
        {
        if (Status is not ReservationStatus.Reserved)
            {
            return Result.Failure(ReservationErrors.NotReserved);
            }

        Status = ReservationStatus.Rejected;
        RejectedUTC = utcNow;
        RaiseDomainEvent(new ReservationRejectedDomainEvent(Id));

        return Result.Success();
        }


    public Result Complete ( DateTime utcNow )
        {
        if (Status is not ReservationStatus.Confirmed)
            {
            return Result.Failure(ReservationErrors.NotConfirmed);
            }

        Status = ReservationStatus.Completed;
        CompletedUTC = utcNow;
        RaiseDomainEvent(new ReservationCompletedDomainEvent(Id));

        return Result.Success();
        }

    public Result Finish ( DateTime utcNow )
        {
        if (Status is not ReservationStatus.Completed)
            {
            return Result.Failure(ReservationErrors.NotCompeleted);
            }

        Status = ReservationStatus.Finished;
        FinishedUTC = utcNow;
        RaiseDomainEvent(new ReservationFinishedDomainEvent(Id));

        return Result.Success();
        }

    public Result Cancel ( DateTime utcNow )
        {
        if (Status is not ReservationStatus.Confirmed)
            {
            return Result.Failure(ReservationErrors.NotConfirmed);
            }

        var currentDate = DateOnly.FromDateTime(utcNow);
        if (currentDate > Duration.BeginDate)
            {
            return Result.Failure(ReservationErrors.AlreadyBegun);
            }

        Status = ReservationStatus.Cancelled;
        CancelledUTC = utcNow;
        RaiseDomainEvent(new ReservationCanceledDomainEvent(Id));

        return Result.Success();
        }
    }