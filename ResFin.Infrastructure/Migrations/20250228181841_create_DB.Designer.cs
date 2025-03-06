﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResFin.Infrastructure;

#nullable disable

namespace ResFin.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250228181841_create_DB")]
    partial class create_DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ResFin.Domain.Residences.Events.Reservations.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CancelledUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cancelled_utc");

                    b.Property<DateTime?>("CompletedUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("completed_utc");

                    b.Property<DateTime?>("ConfirmedUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("confirmed_utc");

                    b.Property<DateTime>("CreatedUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_utc");

                    b.Property<DateTime?>("FinishedUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("finished_utc");

                    b.Property<DateTime?>("RejectedUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rejected_utc");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("uuid")
                        .HasColumnName("residence_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_reservations");

                    b.HasIndex("ResidenceId")
                        .HasDatabaseName("ix_reservations_residence_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reservations_user_id");

                    b.ToTable("reservations", (string)null);
                });

            modelBuilder.Entity("ResFin.Domain.Residences.Residence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.PrimitiveCollection<int[]>("Amenities")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("amenities");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("LastBookedUTC")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_booked_utc");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<int>("ResidenceType")
                        .HasColumnType("integer")
                        .HasColumnName("residence_type");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_residences");

                    b.ToTable("residences", (string)null);
                });

            modelBuilder.Entity("ResFin.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_utc");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uuid")
                        .HasColumnName("reservation_id");

                    b.Property<Guid>("ResidenceId")
                        .HasColumnType("uuid")
                        .HasColumnName("residence_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("ReservationId")
                        .HasDatabaseName("ix_reviews_reservation_id");

                    b.HasIndex("ResidenceId")
                        .HasDatabaseName("ix_reviews_residence_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_user_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("ResFin.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<int>("UserType")
                        .HasColumnType("integer")
                        .HasColumnName("user_type");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ResFin.Domain.Residences.Events.Reservations.Reservation", b =>
                {
                    b.HasOne("ResFin.Domain.Residences.Residence", null)
                        .WithMany()
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reservations_residence_residence_id");

                    b.HasOne("ResFin.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reservations_user_user_id");

                    b.OwnsOne("ResFin.Domain.Residences.Events.Reservations.Duration", "Duration", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateOnly>("BeginDate")
                                .HasColumnType("date")
                                .HasColumnName("duration_begin_date");

                            b1.Property<DateOnly>("EndDate")
                                .HasColumnType("date")
                                .HasColumnName("duration_end_date");

                            b1.HasKey("ReservationId");

                            b1.ToTable("reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId")
                                .HasConstraintName("fk_reservations_reservations_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "AmenitiesUpCharge", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("amenities_up_charge_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("amenities_up_charge_currency");

                            b1.HasKey("ReservationId");

                            b1.ToTable("reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId")
                                .HasConstraintName("fk_reservations_reservations_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "CleansingFee", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("cleansing_fee_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("cleansing_fee_currency");

                            b1.HasKey("ReservationId");

                            b1.ToTable("reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId")
                                .HasConstraintName("fk_reservations_reservations_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "Discount", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("discount_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("discount_currency");

                            b1.HasKey("ReservationId");

                            b1.ToTable("reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId")
                                .HasConstraintName("fk_reservations_reservations_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "RentingPrice", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("renting_price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("renting_price_currency");

                            b1.HasKey("ReservationId");

                            b1.ToTable("reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId")
                                .HasConstraintName("fk_reservations_reservations_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("ReservationId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("total_price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("total_price_currency");

                            b1.HasKey("ReservationId");

                            b1.ToTable("reservations");

                            b1.WithOwner()
                                .HasForeignKey("ReservationId")
                                .HasConstraintName("fk_reservations_reservations_id");
                        });

                    b.Navigation("AmenitiesUpCharge")
                        .IsRequired();

                    b.Navigation("CleansingFee")
                        .IsRequired();

                    b.Navigation("Discount")
                        .IsRequired();

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("RentingPrice")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("ResFin.Domain.Residences.Residence", b =>
                {
                    b.OwnsOne("ResFin.Domain.Shared.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("ResidenceId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Alley")
                                .HasColumnType("text")
                                .HasColumnName("address_alley");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_country");

                            b1.Property<string>("Number")
                                .HasColumnType("text")
                                .HasColumnName("address_number");

                            b1.Property<string>("StateOrProvince")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_state_or_province");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text")
                                .HasColumnName("address_zip_code");

                            b1.HasKey("ResidenceId");

                            b1.ToTable("residences");

                            b1.WithOwner()
                                .HasForeignKey("ResidenceId")
                                .HasConstraintName("fk_residences_residences_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "CleaningFee", b1 =>
                        {
                            b1.Property<Guid>("ResidenceId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("cleaning_fee_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("cleaning_fee_currency");

                            b1.HasKey("ResidenceId");

                            b1.ToTable("residences");

                            b1.WithOwner()
                                .HasForeignKey("ResidenceId")
                                .HasConstraintName("fk_residences_residences_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "PriceDiscount", b1 =>
                        {
                            b1.Property<Guid>("ResidenceId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("price_discount_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_discount_currency");

                            b1.HasKey("ResidenceId");

                            b1.ToTable("residences");

                            b1.WithOwner()
                                .HasForeignKey("ResidenceId")
                                .HasConstraintName("fk_residences_residences_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Money", "PricePerNight", b1 =>
                        {
                            b1.Property<Guid>("ResidenceId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("price_per_night_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_per_night_currency");

                            b1.HasKey("ResidenceId");

                            b1.ToTable("residences");

                            b1.WithOwner()
                                .HasForeignKey("ResidenceId")
                                .HasConstraintName("fk_residences_residences_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("CleaningFee")
                        .IsRequired();

                    b.Navigation("PriceDiscount");

                    b.Navigation("PricePerNight")
                        .IsRequired();
                });

            modelBuilder.Entity("ResFin.Domain.Reviews.Review", b =>
                {
                    b.HasOne("ResFin.Domain.Residences.Events.Reservations.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_reservations_reservation_id");

                    b.HasOne("ResFin.Domain.Residences.Residence", null)
                        .WithMany()
                        .HasForeignKey("ResidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_residences_residence_id");

                    b.HasOne("ResFin.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_user_user_id");
                });

            modelBuilder.Entity("ResFin.Domain.Users.User", b =>
                {
                    b.OwnsOne("ResFin.Domain.Users.CellPhone", "CellPhone", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("cell_phone_value");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("ResFin.Domain.Users.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasColumnType("text")
                                .HasColumnName("phone_value");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.OwnsOne("ResFin.Domain.Shared.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Alley")
                                .HasColumnType("text")
                                .HasColumnName("address_alley");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_country");

                            b1.Property<string>("Number")
                                .HasColumnType("text")
                                .HasColumnName("address_number");

                            b1.Property<string>("StateOrProvince")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_state_or_province");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text")
                                .HasColumnName("address_zip_code");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId")
                                .HasConstraintName("fk_users_users_id");
                        });

                    b.Navigation("Address");

                    b.Navigation("CellPhone")
                        .IsRequired();

                    b.Navigation("Phone");
                });
#pragma warning restore 612, 618
        }
    }
}
