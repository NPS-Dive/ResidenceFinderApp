namespace ResFin.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
    public void Configure ( EntityTypeBuilder<User> builder )
        {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.OwnsOne(user => user.Address);
        builder.OwnsOne(user => user.CellPhone);
        builder.OwnsOne(user => user.Phone);

        builder.Ignore(user=>user.Phone);

        builder.Property(user => user.FirstName)
            .HasMaxLength(50)
            .HasConversion(firstname => firstname.Value, value => new FirstName(value));

        builder.Property(user => user.LastName)
            .HasMaxLength(50)
            .HasConversion(lastName => lastName.Value, value => new LastName(value));

        builder.Property(user => user.Email)
            .HasMaxLength(50)
            .HasConversion(email => email.Value, value => new Domain.Users.Email(value));

        builder.HasIndex(user => user.Email).IsUnique();

        builder.HasIndex(user => user.IdentityId).IsUnique();
        
        }
    }