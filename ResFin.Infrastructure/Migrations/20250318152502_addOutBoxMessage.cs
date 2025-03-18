using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResFin.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addOutBoxMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_roles_RoleId",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_residences_ResidenceId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_users_UserId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_reservations_ReservationId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_residences_ResidenceId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_roles_RolesId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_users_UsersId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role_permission",
                table: "role_permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reviews",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_residences",
                table: "residences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "CellPhone_Value",
                table: "users");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                newName: "role_user");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "users",
                newName: "address_street");

            migrationBuilder.RenameColumn(
                name: "Address_Number",
                table: "users",
                newName: "address_number");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "users",
                newName: "address_country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "users",
                newName: "address_city");

            migrationBuilder.RenameColumn(
                name: "Address_Alley",
                table: "users",
                newName: "address_alley");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "users",
                newName: "user_type");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IdentityId",
                table: "users",
                newName: "identity_id");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Phone_Value",
                table: "users",
                newName: "cell_phone_value");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "users",
                newName: "address_zip_code");

            migrationBuilder.RenameColumn(
                name: "Address_StateOrProvince",
                table: "users",
                newName: "address_state_or_province");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "users",
                newName: "ix_users_email");

            migrationBuilder.RenameIndex(
                name: "IX_users_IdentityId",
                table: "users",
                newName: "ix_users_identity_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "role_permission",
                newName: "permission_id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "role_permission",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "reviews",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "reviews",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reviews",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reviews",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ResidenceId",
                table: "reviews",
                newName: "residence_id");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "reviews",
                newName: "reservation_id");

            migrationBuilder.RenameColumn(
                name: "CreatedUtc",
                table: "reviews",
                newName: "created_utc");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                newName: "ix_reviews_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_ResidenceId",
                table: "reviews",
                newName: "ix_reviews_residence_id");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_ReservationId",
                table: "reviews",
                newName: "ix_reviews_reservation_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "residences",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "residences",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "residences",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "Amenities",
                table: "residences",
                newName: "amenities");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "residences",
                newName: "address_street");

            migrationBuilder.RenameColumn(
                name: "Address_Number",
                table: "residences",
                newName: "address_number");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "residences",
                newName: "address_country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "residences",
                newName: "address_city");

            migrationBuilder.RenameColumn(
                name: "Address_Alley",
                table: "residences",
                newName: "address_alley");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "residences",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ResidenceType",
                table: "residences",
                newName: "residence_type");

            migrationBuilder.RenameColumn(
                name: "LastBookedUTC",
                table: "residences",
                newName: "last_booked_utc");

            migrationBuilder.RenameColumn(
                name: "PricePerNight_Currency",
                table: "residences",
                newName: "price_per_night_currency");

            migrationBuilder.RenameColumn(
                name: "PricePerNight_Amount",
                table: "residences",
                newName: "price_per_night_amount");

            migrationBuilder.RenameColumn(
                name: "PriceDiscount_Currency",
                table: "residences",
                newName: "price_discount_currency");

            migrationBuilder.RenameColumn(
                name: "PriceDiscount_Amount",
                table: "residences",
                newName: "price_discount_amount");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Currency",
                table: "residences",
                newName: "cleaning_fee_currency");

            migrationBuilder.RenameColumn(
                name: "CleaningFee_Amount",
                table: "residences",
                newName: "cleaning_fee_amount");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "residences",
                newName: "address_zip_code");

            migrationBuilder.RenameColumn(
                name: "Address_StateOrProvince",
                table: "residences",
                newName: "address_state_or_province");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "reservations",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Discount_Currency",
                table: "reservations",
                newName: "discount_currency");

            migrationBuilder.RenameColumn(
                name: "Discount_Amount",
                table: "reservations",
                newName: "discount_amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reservations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reservations",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ResidenceId",
                table: "reservations",
                newName: "residence_id");

            migrationBuilder.RenameColumn(
                name: "RejectedUTC",
                table: "reservations",
                newName: "rejected_utc");

            migrationBuilder.RenameColumn(
                name: "FinishedUTC",
                table: "reservations",
                newName: "finished_utc");

            migrationBuilder.RenameColumn(
                name: "CreatedUTC",
                table: "reservations",
                newName: "created_utc");

            migrationBuilder.RenameColumn(
                name: "ConfirmedUTC",
                table: "reservations",
                newName: "confirmed_utc");

            migrationBuilder.RenameColumn(
                name: "CompletedUTC",
                table: "reservations",
                newName: "completed_utc");

            migrationBuilder.RenameColumn(
                name: "CancelledUTC",
                table: "reservations",
                newName: "cancelled_utc");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Currency",
                table: "reservations",
                newName: "total_price_currency");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Amount",
                table: "reservations",
                newName: "total_price_amount");

            migrationBuilder.RenameColumn(
                name: "RentingPrice_Currency",
                table: "reservations",
                newName: "renting_price_currency");

            migrationBuilder.RenameColumn(
                name: "RentingPrice_Amount",
                table: "reservations",
                newName: "renting_price_amount");

            migrationBuilder.RenameColumn(
                name: "Duration_EndDate",
                table: "reservations",
                newName: "duration_end_date");

            migrationBuilder.RenameColumn(
                name: "Duration_BeginDate",
                table: "reservations",
                newName: "duration_begin_date");

            migrationBuilder.RenameColumn(
                name: "CleansingFee_Currency",
                table: "reservations",
                newName: "cleansing_fee_currency");

            migrationBuilder.RenameColumn(
                name: "CleansingFee_Amount",
                table: "reservations",
                newName: "cleansing_fee_amount");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpCharge_Currency",
                table: "reservations",
                newName: "amenities_up_charge_currency");

            migrationBuilder.RenameColumn(
                name: "AmenitiesUpCharge_Amount",
                table: "reservations",
                newName: "amenities_up_charge_amount");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_UserId",
                table: "reservations",
                newName: "ix_reservations_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_ResidenceId",
                table: "reservations",
                newName: "ix_reservations_residence_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "permissions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "permissions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "permissions",
                newName: "role_id");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_RoleId",
                table: "permissions",
                newName: "ix_permissions_role_id");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "role_user",
                newName: "users_id");

            migrationBuilder.RenameColumn(
                name: "RolesId",
                table: "role_user",
                newName: "roles_id");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UsersId",
                table: "role_user",
                newName: "ix_role_user_users_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_roles",
                table: "roles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_permission",
                table: "role_permission",
                columns: new[] { "role_id", "permission_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_reviews",
                table: "reviews",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_residences",
                table: "residences",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_reservations",
                table: "reservations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_permissions",
                table: "permissions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_user",
                table: "role_user",
                columns: new[] { "roles_id", "users_id" });

            migrationBuilder.CreateTable(
                name: "outbox_messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    occurred_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "jsonb", nullable: false),
                    processed_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_messages", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_permissions_role_role_id",
                table: "permissions",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_residence_residence_id",
                table: "reservations",
                column: "residence_id",
                principalTable: "residences",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reservations_user_user_id",
                table: "reservations",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_reservations_reservation_id",
                table: "reviews",
                column: "reservation_id",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_residences_residence_id",
                table: "reviews",
                column: "residence_id",
                principalTable: "residences",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_reviews_user_user_id",
                table: "reviews",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_user_role_roles_id",
                table: "role_user",
                column: "roles_id",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_user_user_users_id",
                table: "role_user",
                column: "users_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_permissions_role_role_id",
                table: "permissions");

            migrationBuilder.DropForeignKey(
                name: "fk_reservations_residence_residence_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "fk_reservations_user_user_id",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_reservations_reservation_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_residences_residence_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_reviews_user_user_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "fk_role_user_role_roles_id",
                table: "role_user");

            migrationBuilder.DropForeignKey(
                name: "fk_role_user_user_users_id",
                table: "role_user");

            migrationBuilder.DropTable(
                name: "outbox_messages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_permission",
                table: "role_permission");

            migrationBuilder.DropPrimaryKey(
                name: "pk_reviews",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "pk_residences",
                table: "residences");

            migrationBuilder.DropPrimaryKey(
                name: "pk_reservations",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_permissions",
                table: "permissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_user",
                table: "role_user");

            migrationBuilder.RenameTable(
                name: "role_user",
                newName: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address_street",
                table: "users",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "address_number",
                table: "users",
                newName: "Address_Number");

            migrationBuilder.RenameColumn(
                name: "address_country",
                table: "users",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "address_city",
                table: "users",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "address_alley",
                table: "users",
                newName: "Address_Alley");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_type",
                table: "users",
                newName: "UserType");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "identity_id",
                table: "users",
                newName: "IdentityId");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "cell_phone_value",
                table: "users",
                newName: "Phone_Value");

            migrationBuilder.RenameColumn(
                name: "address_zip_code",
                table: "users",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "address_state_or_province",
                table: "users",
                newName: "Address_StateOrProvince");

            migrationBuilder.RenameIndex(
                name: "ix_users_email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameIndex(
                name: "ix_users_identity_id",
                table: "users",
                newName: "IX_users_IdentityId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "permission_id",
                table: "role_permission",
                newName: "PermissionId");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "role_permission",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "reviews",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "residence_id",
                table: "reviews",
                newName: "ResidenceId");

            migrationBuilder.RenameColumn(
                name: "reservation_id",
                table: "reviews",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "created_utc",
                table: "reviews",
                newName: "CreatedUtc");

            migrationBuilder.RenameIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                newName: "IX_reviews_UserId");

            migrationBuilder.RenameIndex(
                name: "ix_reviews_residence_id",
                table: "reviews",
                newName: "IX_reviews_ResidenceId");

            migrationBuilder.RenameIndex(
                name: "ix_reviews_reservation_id",
                table: "reviews",
                newName: "IX_reviews_ReservationId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "residences",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "residences",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "residences",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "amenities",
                table: "residences",
                newName: "Amenities");

            migrationBuilder.RenameColumn(
                name: "address_street",
                table: "residences",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "address_number",
                table: "residences",
                newName: "Address_Number");

            migrationBuilder.RenameColumn(
                name: "address_country",
                table: "residences",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "address_city",
                table: "residences",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "address_alley",
                table: "residences",
                newName: "Address_Alley");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "residences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "residence_type",
                table: "residences",
                newName: "ResidenceType");

            migrationBuilder.RenameColumn(
                name: "last_booked_utc",
                table: "residences",
                newName: "LastBookedUTC");

            migrationBuilder.RenameColumn(
                name: "price_per_night_currency",
                table: "residences",
                newName: "PricePerNight_Currency");

            migrationBuilder.RenameColumn(
                name: "price_per_night_amount",
                table: "residences",
                newName: "PricePerNight_Amount");

            migrationBuilder.RenameColumn(
                name: "price_discount_currency",
                table: "residences",
                newName: "PriceDiscount_Currency");

            migrationBuilder.RenameColumn(
                name: "price_discount_amount",
                table: "residences",
                newName: "PriceDiscount_Amount");

            migrationBuilder.RenameColumn(
                name: "cleaning_fee_currency",
                table: "residences",
                newName: "CleaningFee_Currency");

            migrationBuilder.RenameColumn(
                name: "cleaning_fee_amount",
                table: "residences",
                newName: "CleaningFee_Amount");

            migrationBuilder.RenameColumn(
                name: "address_zip_code",
                table: "residences",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "address_state_or_province",
                table: "residences",
                newName: "Address_StateOrProvince");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "reservations",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "discount_currency",
                table: "reservations",
                newName: "Discount_Currency");

            migrationBuilder.RenameColumn(
                name: "discount_amount",
                table: "reservations",
                newName: "Discount_Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reservations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "reservations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "residence_id",
                table: "reservations",
                newName: "ResidenceId");

            migrationBuilder.RenameColumn(
                name: "rejected_utc",
                table: "reservations",
                newName: "RejectedUTC");

            migrationBuilder.RenameColumn(
                name: "finished_utc",
                table: "reservations",
                newName: "FinishedUTC");

            migrationBuilder.RenameColumn(
                name: "created_utc",
                table: "reservations",
                newName: "CreatedUTC");

            migrationBuilder.RenameColumn(
                name: "confirmed_utc",
                table: "reservations",
                newName: "ConfirmedUTC");

            migrationBuilder.RenameColumn(
                name: "completed_utc",
                table: "reservations",
                newName: "CompletedUTC");

            migrationBuilder.RenameColumn(
                name: "cancelled_utc",
                table: "reservations",
                newName: "CancelledUTC");

            migrationBuilder.RenameColumn(
                name: "total_price_currency",
                table: "reservations",
                newName: "TotalPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "total_price_amount",
                table: "reservations",
                newName: "TotalPrice_Amount");

            migrationBuilder.RenameColumn(
                name: "renting_price_currency",
                table: "reservations",
                newName: "RentingPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "renting_price_amount",
                table: "reservations",
                newName: "RentingPrice_Amount");

            migrationBuilder.RenameColumn(
                name: "duration_end_date",
                table: "reservations",
                newName: "Duration_EndDate");

            migrationBuilder.RenameColumn(
                name: "duration_begin_date",
                table: "reservations",
                newName: "Duration_BeginDate");

            migrationBuilder.RenameColumn(
                name: "cleansing_fee_currency",
                table: "reservations",
                newName: "CleansingFee_Currency");

            migrationBuilder.RenameColumn(
                name: "cleansing_fee_amount",
                table: "reservations",
                newName: "CleansingFee_Amount");

            migrationBuilder.RenameColumn(
                name: "amenities_up_charge_currency",
                table: "reservations",
                newName: "AmenitiesUpCharge_Currency");

            migrationBuilder.RenameColumn(
                name: "amenities_up_charge_amount",
                table: "reservations",
                newName: "AmenitiesUpCharge_Amount");

            migrationBuilder.RenameIndex(
                name: "ix_reservations_user_id",
                table: "reservations",
                newName: "IX_reservations_UserId");

            migrationBuilder.RenameIndex(
                name: "ix_reservations_residence_id",
                table: "reservations",
                newName: "IX_reservations_ResidenceId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "permissions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "permissions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "permissions",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "ix_permissions_role_id",
                table: "permissions",
                newName: "IX_permissions_RoleId");

            migrationBuilder.RenameColumn(
                name: "users_id",
                table: "RoleUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "roles_id",
                table: "RoleUser",
                newName: "RolesId");

            migrationBuilder.RenameIndex(
                name: "ix_role_user_users_id",
                table: "RoleUser",
                newName: "IX_RoleUser_UsersId");

            migrationBuilder.AddColumn<string>(
                name: "CellPhone_Value",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role_permission",
                table: "role_permission",
                columns: new[] { "RoleId", "PermissionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_reviews",
                table: "reviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_residences",
                table: "residences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_roles_RoleId",
                table: "permissions",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_residences_ResidenceId",
                table: "reservations",
                column: "ResidenceId",
                principalTable: "residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_users_UserId",
                table: "reservations",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_reservations_ReservationId",
                table: "reviews",
                column: "ReservationId",
                principalTable: "reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_residences_ResidenceId",
                table: "reviews",
                column: "ResidenceId",
                principalTable: "residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_roles_RolesId",
                table: "RoleUser",
                column: "RolesId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_users_UsersId",
                table: "RoleUser",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
