using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class ReservationDate
    {
        [Key]
        public int ReservationDateID { get; set; }
        public DateTime Date { get; set; }
        public int ReservationHourId { get; set; }   
        public ReservationHours ReservationHour { get; set; }

        public string DayName { get; set; }  
        public TimeSpan Time { get; set; }
        public bool IsAvailable { get; set; } = true;

        public ICollection<Reserved> Reserveds { get; set; }
        public int BarberID { get; set; } // EKLENMİŞ OLMALI
        public Barber Barber { get; set; }
    }
}
