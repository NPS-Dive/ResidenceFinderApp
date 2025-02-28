namespace ResFin.Application.Reservations.GetReservation;

public sealed class ReservationResponse
    {
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Guid ResidenceId { get; init; }
    public int Status { get; init; }
    public decimal PriceAmount { get; init; }
    public string PriceCurrency { get; init; }
    public decimal CleaningFeeAmount { get; init; }
    public decimal CleaningFeeCurrency { get; init; }
    public decimal AmenitiesUpChargeAmount { get; init; }
    public decimal AmenitiesUpChargeCurrency { get; init; }
    public decimal DiscountAmount { get; init; }
    public string DiscountCurrency { get; init; }
    public decimal TotalPriceAmount { get; init; }
    public string TotalPriceCurrency { get; init; }
    public DateOnly DurationBegin { get; init; }
    public DateOnly DurationEnd { get; init; }
    public DateTime CreatedUtc { get; init; }
    }