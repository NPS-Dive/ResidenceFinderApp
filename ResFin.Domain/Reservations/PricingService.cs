using ResFin.Domain.Shared;

namespace ResFin.Domain.Residences.Events.Reservations;

public class PricingService
    {
    public PricingDetails BillCalculator ( Residence residence, Duration duration )
        {
        var currency = residence.PricePerNight.Currency;

        var discount = new Money(residence.PriceDiscount.Amount, currency);

        var rowPriceForDuration = new Money((residence.PricePerNight.Amount * duration.DurationInDays), currency);


        decimal upChargePercent = 0;

        foreach (var amenity in residence.Amenities)
            {
            upChargePercent += (decimal)(amenity switch
                {
                    Amenity.Gym => 0.1,
                    Amenity.Spa => 0.5,
                    Amenity.SwimmingPool => 0.5,
                    Amenity.Parking => 0.2,
                    Amenity.Balcony => 0.1,
                    Amenity.Terrace => 0.1,
                    Amenity.Bar => 1.8,
                    Amenity.Barbecue => 0.1,
                    Amenity.Wifi => 0.5,
                    _ => 0
                    });
            }

        var amenitiesUpCharge = Money.Zero(currency);

        if (upChargePercent > 0)
            {
            amenitiesUpCharge = new Money(rowPriceForDuration.Amount * upChargePercent, currency);
            }

        var totalPrice = Money.Zero(currency);
        totalPrice += rowPriceForDuration;

        if (!residence.CleaningFee.IsZero())
            {
            totalPrice += residence.CleaningFee;
            }

        totalPrice += amenitiesUpCharge;
        var finalPrice = new Money((totalPrice.Amount - discount.Amount), currency);

        var result = new PricingDetails(rowPriceForDuration, residence.CleaningFee, amenitiesUpCharge, discount, finalPrice);
        
        return result;
        }
    }