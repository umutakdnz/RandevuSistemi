using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Reserved
    {
        [Key]
        public int ReservedID { get; set; }
        public string? NameSurname { get; set; }
        public DateTime? Date { get; set; }
        public string? PhoneNo { get; set; }
        public TimeSpan? Time { get; set; }
        public string? Description { get; set; }
        public int BarberID { get; set; } // Foreign Key
        public Barber Barber { get; set; }
        public string? Situation { get; set; }

        public DateTime ReservationDate { get; set; }

        public int ReservationDaysID { get; set; }
        public ReservationDays ReservationDays { get; set; }

        public int ReservationHoursID { get; set; }
        public ReservationHours ReservationHours { get; set; }

        public int? ReservationDateID { get; set; }
        public ReservationDate ReservationDates { get; set; }
    }
}
