namespace ResFin.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
    {
    public DateTime UtcNow => DateTime.UtcNow;
    }