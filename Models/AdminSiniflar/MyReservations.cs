using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class MyReservations
    {
        [Key]
        public int MyReservationsID { get; set; }
        public string Barber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public string Situation { get; set; }
    }
}
