
namespace ResFin.Application.Residences.SearchResidences;

public sealed  record SearchResidencesQuery(
        DateOnly BeginDate,
        DateOnly EndDate
    ): IQuery<IReadOnlyList<ResidenceResponse>>;