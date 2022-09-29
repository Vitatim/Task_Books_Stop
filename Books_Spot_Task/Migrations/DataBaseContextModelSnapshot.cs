﻿// <auto-generated />
using System;
using Books_Spot_Task.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Books_Spot_Task.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Books_Spot_Task.Entities.BookEntity", b =>
                {
                    b.Property<string>("IsbnCode")
                        .HasColumnType("text");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("BookStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IsbnCode");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Books_Spot_Task.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("BookingCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DateBorrowed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateReserved")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateReturned")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IsbnCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LibraryCardId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookingCode");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Books_Spot_Task.Entities.GenreEntity", b =>
                {
                    b.Property<string>("GenreName")
                        .HasColumnType("text");

                    b.HasKey("GenreName");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Books_Spot_Task.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LibraryCardId")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
