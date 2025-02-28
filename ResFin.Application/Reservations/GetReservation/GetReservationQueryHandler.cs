

namespace ResFin.Application.Reservations.GetReservation;

internal sealed class GetReservationQueryHandler : IQueryHandler<GetReservationQuery, ReservationResponse>
    {
    private readonly ISqlConnectionFactory _sqlConnection;

    public GetReservationQueryHandler ( ISqlConnectionFactory sqlConnection )
        {
        _sqlConnection = sqlConnection;
        }

    public async Task<Result<ReservationResponse>> Handle (
        GetReservationQuery request,
        CancellationToken cancellationToken )
        {
        using var connection = _sqlConnection.CreateConnection();

        const string sql = """
                         SELECT
                                id AS Id,
                                residence_Id AS ResidenceId,
                                status AS Status,
                                price_for_period_amount AS PriceAmount ,
                                price_for_currency AS PriceCurrency,
                                cleaning_fee_amount AS CleaningFeeAmount,
                                cleaning_fee_currency AS CleaningFeeCurrency,
                                amenities_up_charge_amount AS AmenitiesUpChargeAmount,
                                amenities_up_charge_currency AS AmenitiesUpChargeCurrency,
                                discount_amount AS DiscountAmount,
                                discount_currency AS DiscountCurrency,
                                total_price_amount AS TotalPriceAmount,
                                total_price_currency AS TotalPriceCurrency,
                                duration_begin AS DurationBegin,
                                duration_end AS DurationEnd,
                                created_utc AS CreatedUtc
                         FROM reservations
                         WHERE id= @ReservationId
                         """;

        var reservation = await connection.QueryFirstOrDefaultAsync(
            sql,
            new
                {
                request.ReservationId
                });

        return reservation;
        }
    }