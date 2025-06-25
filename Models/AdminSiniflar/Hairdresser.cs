using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Hairdresser
    {
        [Key]
        public int HairdresserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; } = null;
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public int BarberID { get; set; } // Foreign Key
        public Barber Barber { get; set; }
    }
}
