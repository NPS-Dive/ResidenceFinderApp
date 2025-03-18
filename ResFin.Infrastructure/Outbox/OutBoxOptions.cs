namespace ResFin.Infrastructure.Outbox;

public class OutBoxOptions
    {
    public int IntervalInSeconds { get; init; }
    public int BatchSize { get; init; }
    }