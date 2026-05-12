using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class EventManagementContext : DbContext
{
    public EventManagementContext()
    {
    }

    public EventManagementContext(DbContextOptions<EventManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=EventDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.Property(e => e.BookingStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeventId).HasColumnName("FEventId");

            entity.HasOne(d => d.Attendee).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.AttendeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Users");

            entity.HasOne(d => d.Fevent).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FeventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bookings_Events");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FcategoryId).HasColumnName("FCategoryId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Venue)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Fcategory).WithMany(p => p.Events)
                .HasForeignKey(d => d.FcategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Categories");

            entity.HasOne(d => d.Organizer).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrganizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Events_Users");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RattendeeId).HasColumnName("RAttendeeId");
            entity.Property(e => e.ReventId).HasColumnName("REventId");

            entity.HasOne(d => d.Rattendee).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.RattendeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Users");

            entity.HasOne(d => d.Revent).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ReventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Events");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FroleId).HasColumnName("FRoleId");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Frole).WithMany(p => p.Users)
                .HasForeignKey(d => d.FroleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
