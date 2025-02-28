namespace ResFin.Infrastructure.Configurations;

internal sealed class ResidenceConfiguration : IEntityTypeConfiguration<Residence>
    {
    public void Configure ( EntityTypeBuilder<Residence> builder )
        {
        builder.ToTable("residences");

        builder.HasKey(residence => residence.Id);

        builder.OwnsOne(residence => residence.Address);

        builder.Property(residence => residence.Name)
            .HasMaxLength(100)
            .HasConversion(name => name.Value, value => new Name(value));

        builder.Property(residence => residence.Description)
            .HasMaxLength(2000)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.OwnsOne(residence => residence.PricePerNight, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        builder.OwnsOne(residence => residence.CleaningFee, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        builder.OwnsOne(residence => residence.PriceDiscount, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        //optimistic concurrency with a shadow property
        builder.Property<uint>("Version").IsRowVersion();
        }

    }