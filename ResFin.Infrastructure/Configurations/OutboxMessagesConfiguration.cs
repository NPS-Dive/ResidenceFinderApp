using ResFin.Infrastructure.Outbox;

namespace ResFin.Infrastructure.Configurations;

internal sealed class OutboxMessagesConfiguration      :IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("outbox_messages");
      
        builder
            .HasKey(obm => obm.Id);

        builder
            .Property(obm => obm.Content)
            .HasColumnType("jsonb");
    }
}