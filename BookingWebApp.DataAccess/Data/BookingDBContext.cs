using System;
using System.Collections.Generic;
using BookingWebApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingWebApp.DataAccess.Data
{
    public partial class BookingDBContext : DbContext
    {
        public BookingDBContext()
        {
        }

        public BookingDBContext(DbContextOptions<BookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.ClientId, e.RoomId })
                    .HasName("PK__Booking__0EB7D18CEA2D4862");

                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("datetime")
                    .HasColumnName("check_in_date");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("datetime")
                    .HasColumnName("check_out_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Client");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Room");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.EMail)
                    .HasMaxLength(30)
                    .HasColumnName("e_mail");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(128)
                    .HasColumnName("password_hash");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.Addr)
                    .HasMaxLength(60)
                    .HasColumnName("addr");

                entity.Property(e => e.EMail)
                    .HasMaxLength(30)
                    .HasColumnName("e_mail");

                entity.Property(e => e.HotelName)
                    .HasMaxLength(30)
                    .HasColumnName("hotel_name");

                entity.Property(e => e.NumberOfFloors).HasColumnName("number_of_floors");

                entity.Property(e => e.NumberOfRooms).HasColumnName("number_of_rooms");

                entity.Property(e => e.Parking).HasColumnName("parking");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(128)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.FloorNumber).HasColumnName("floor_number");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.IsLuxe).HasColumnName("is_luxe");

                entity.Property(e => e.NumberOfBedrooms).HasColumnName("number_of_bedrooms");

                entity.Property(e => e.NumberOfBeds).HasColumnName("number_of_beds");

                entity.Property(e => e.RoomNumber).HasColumnName("room_number");

                entity.Property(e => e.PricePerDay)
                    .HasColumnType("money")
                    .HasColumnName("price_per_day");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Hotel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
