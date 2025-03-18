using Quartz;

namespace ResFin.Infrastructure.Outbox;

public class ProcessOutBoxMessagesJobSetUp : IConfigureOptions<QuartzOptions>
    {
    private readonly OutBoxOptions _outBoxOptions;

    public ProcessOutBoxMessagesJobSetUp ( IOptions<OutBoxOptions> outBoxOptions )
        {
        _outBoxOptions = outBoxOptions.Value;
        }

    public void Configure ( QuartzOptions options )
        {
        const string jobName = nameof(ProcessOutBoxMessagesJob);

        options
            .AddJob<ProcessOutBoxMessagesJob>(configure =>
                configure
                    .WithIdentity(jobName))
                    .AddTrigger(configure =>
                        configure
                            .ForJob(jobName)
                            .WithSimpleSchedule(schedule =>
                                schedule.WithIntervalInSeconds(_outBoxOptions.IntervalInSeconds).RepeatForever()));
        }
    }