using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class ReservationHours
    {
        [Key]
        public int ReservationHoursID { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int ReservationDaysID { get; set; }
        public ReservationDays ReservationDays { get; set; }
        public ICollection<Reserved> Reserveds { get; set; }
        public ICollection<ReservationDate> ReservationDate { get; set; }
        public int BarberID { get; set; } // EKLENMİŞ OLMALI
        public Barber Barber { get; set; }
    }
}
