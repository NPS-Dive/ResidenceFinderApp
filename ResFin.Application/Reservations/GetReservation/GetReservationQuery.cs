using ResFin.Application.Abstractions.Caching;

namespace ResFin.Application.Reservations.GetReservation;

public sealed record GetReservationQuery (Guid ReservationId) : ICachedQuery<ReservationResponse>
{
    public string CacheKey => $"Reservations-{ReservationId}";
    public TimeSpan? Expiration => null;
}