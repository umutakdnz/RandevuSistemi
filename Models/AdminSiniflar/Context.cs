using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Context : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Campaigns> Campaigns { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Hairdresser> Hairdressers { get; set; }
        public DbSet<Services> Services { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<MyReservations> MyReservations { get; set; }
        public DbSet<CustomerComment> CustomerComments { get; set; }
        public DbSet<Reserved> Reserveds { get; set; }
        public DbSet<ReservationDays> ReservationsDays { get; set; }
        public DbSet<ReservationHours> ReservationHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserved>()
                .HasOne(r => r.Barber)
                .WithMany(b => b.Reserveds)
                .HasForeignKey(r => r.BarberID)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine

            modelBuilder.Entity<Reserved>()
                .HasOne(r => r.ReservationDays)
                .WithMany(d => d.Reserveds)
                .HasForeignKey(r => r.ReservationDaysID)
                .OnDelete(DeleteBehavior.Restrict); // veya .NoAction()

            modelBuilder.Entity<Reserved>()
                .HasOne(r => r.ReservationHours)
                .WithMany(h => h.Reserveds)
                .HasForeignKey(r => r.ReservationHoursID)
                .OnDelete(DeleteBehavior.Restrict); // veya .NoAction()
        }

        public DbSet<ReservationDate> ReservationsDate { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
    }
}
