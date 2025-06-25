using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Barber
    {
        [Key]
        public int BarberId { get; set; }
        public string? BarberName { get; set; }
        public string? BarberNumber { get; set; }
        public string? BarberDescription { get; set; }
        public string? Expertise { get; set; }
        public ICollection<Reserved> Reserveds { get; set; }

        public ICollection<CustomerComment> CustomerComments { get; set; }

        public ICollection<ReservationDays> ReservationDays { get; set; }

        public ICollection<Hairdresser> Hairdresser { get; set; }
        public ICollection<ReservationDate> ReservationDate { get; set; }
        public ICollection<ReservationHours> ReservationHours { get; set; }
    }
}
