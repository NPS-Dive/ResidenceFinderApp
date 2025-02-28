namespace ResFin.Infrastructure.Configurations;

internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
    public void Configure ( EntityTypeBuilder<Review> builder )
        {
        builder.ToTable("reviews");

        builder.HasKey(review => review.Id);

        builder.Property(review=>review.Comment)
            .HasMaxLength(2000)
            .HasConversion(comment=>comment.Value, value=> new Comment(value));

        builder.Property(review => review.Rating)
            .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

        builder.HasOne<Residence>()
            .WithMany()
            .HasForeignKey(review=>review.ResidenceId);

        builder.HasOne<Reservation>()
            .WithMany()
            .HasForeignKey(review => review.ReservationId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(review => review.UserId);

        }
    }