namespace ResFin.Domain.Reservations;

public record Duration
    {
    private Duration ()
        {

        }

    public DateOnly BeginDate { get; init; }
    public DateOnly EndDate { get; init; }
  
    public int DurationInDays => EndDate.DayNumber - BeginDate.DayNumber;

    public static Duration Create(DateOnly begin, DateOnly end)
    {
        if (begin > end)
        {
            throw new ApplicationException("End Date must be after initiation date");
        }

        var resultDuration = new Duration()
        {
            BeginDate = begin,
            EndDate = end
        };

        return resultDuration;
    }
    };