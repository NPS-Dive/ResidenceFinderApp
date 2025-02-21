using System.Security.Policy;
using ResFin.Domain.Shared;

namespace ResFin.Domain.Residences.Events.Reservations;
public record PricingDetails(
    Money RowPriceForDuration,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money Discount,
    Money FinalPrice
    );