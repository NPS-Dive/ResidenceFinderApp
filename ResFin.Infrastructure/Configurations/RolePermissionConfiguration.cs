namespace ResFin.Infrastructure.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
    public void Configure ( EntityTypeBuilder<RolePermission> builder )
        {
        builder.ToTable("role_permission");
        builder.HasKey(rolePermission =>
            new
                {
                rolePermission.RoleId,
                rolePermission.PermissionId
                }
        );

        builder.HasData(
            new RolePermission()
                {
                RoleId = Role.Registered.Id,
                PermissionId = Permission.UsersRead.Id
                });
        }
    }