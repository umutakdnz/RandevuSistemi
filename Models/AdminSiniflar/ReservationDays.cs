using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class ReservationDays
    {
        [Key]
        public int ReservationDaysID { get; set; }
        public string DayName { get; set; }

        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public ICollection<ReservationHours> ReservationHours { get; set; }
        public ICollection<Reserved> Reserveds { get; set; }
    }
}
