using ResFin.Domain.Reservations;

namespace ResFin.Application.Residences.SearchResidences;

internal sealed class SearchResidenceQueryHandler : IQueryHandler<SearchResidencesQuery, IReadOnlyList<ResidenceResponse>>
    {

    private static readonly int[] ActiveReservationStatuses =
    {
        (int)ReservationStatus.Reserved,
        (int)ReservationStatus.Confirmed,
        (int)ReservationStatus.Finished,
        (int)ReservationStatus.Completed
    };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchResidenceQueryHandler ( ISqlConnectionFactory sqlConnectionFactory )
        {
        _sqlConnectionFactory = sqlConnectionFactory;
        }

    public async Task<Result<IReadOnlyList<ResidenceResponse>>> Handle (
        SearchResidencesQuery request,
        CancellationToken cancellationToken )
        {

        if (request.BeginDate > request.EndDate)
            {
            return new List<ResidenceResponse>();
            }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
                             SELECT
                                    a.id AS Id,
                                    a.name AS Name,
                                    a.description AS Description,
                                    a.price_amount AS Price,
                                    a.currency AS Currency,
                                    a.address_country AS Country,
                                    a.address_state_or_province AS StateOrProvince,
                                    a.address_city AS City,
                                    a.address_street AS Street,
                                    a.address_alley AS Alley,
                                    a.address_number AS Number,
                                    a.address_zip_code AS ZipCode
                             FROM residences AS a
                             WHERE NOT EXISTS
                             (
                                    SELECT 1
                                    FROM reservations AS b
                                    WHERE
                                    b.residence_id = a.id AND
                                    b.duration_begin <= @EndDate AND
                                    b.duration_End >= @BeginDate AND
                                    b.status = ANY(@ActiveReservationStatuses) 
                             ) 
                             """;

        var residences = await connection.QueryAsync<ResidenceResponse, AddressResponse, ResidenceResponse>(
             sql,
             ( residence, address ) =>
             {
                 residence.Address = address;
                 return residence;
             },
             new
                 {
                 request.BeginDate,
                 request.EndDate,
                 ActiveReservationStatuses
                 },
             splitOn: "Country"
            );

        return residences.ToList();

        }
    }