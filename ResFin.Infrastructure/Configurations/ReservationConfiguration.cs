namespace ResFin.Infrastructure.Configurations;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
    public void Configure ( EntityTypeBuilder<Reservation> builder )
        {
        builder.ToTable("reservations");

        builder.HasKey(reservation => reservation.Id);

        builder.OwnsOne(reservation => reservation.RentingPrice, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        builder.OwnsOne(reservation => reservation.CleansingFee, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        builder.OwnsOne(reservation => reservation.AmenitiesUpCharge, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        builder.OwnsOne(reservation => reservation.Discount, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });


        builder.OwnsOne(reservation => reservation.TotalPrice, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Type, type => Currency.FromCode(type));
        });

        builder.OwnsOne(reservation => reservation.Duration);

        builder.HasOne<Residence>()
            .WithMany()
            .HasForeignKey(reservation => reservation.ResidenceId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(reservation => reservation.UserId);
        }
    }