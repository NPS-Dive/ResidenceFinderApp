using ResFin.Domain.Reservations;

namespace ResFin.Domain.Reviews;

public sealed class Review : BaseEntity
    {
    private Review (
        Guid id,
        Guid residenceId,
        Guid reservationId,
        Guid userId,
        Rating rating,
        Comment comment,
        DateTime createdUtc
        )
        : base(id)
        {
        ResidenceId = residenceId;
        ReservationId = reservationId;
        UserId = userId;
        Rating = rating;
        Comment = comment;
        CreatedUtc = createdUtc;
        }

    private Review ()
        {

        }

    public Guid ResidenceId { get; private set; }
    public Guid ReservationId { get; private set; }
    public Guid UserId { get; private set; }
    public Rating Rating { get; private set; }
    public Comment Comment { get; private set; }
    public DateTime CreatedUtc { get; private set; }

    public static Result<Review> Create (
        Reservation reservation,
        Rating rating,
        Comment comment,
        DateTime createdUtc )
        {
        if (reservation.Status != ReservationStatus.Completed)
            {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
            }

        var review = new Review(
            Guid.NewGuid(),
            reservation.ResidenceId,
            reservation.Id,
            reservation.UserId,
            rating,
            comment,
            createdUtc
            );

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
        }

    }