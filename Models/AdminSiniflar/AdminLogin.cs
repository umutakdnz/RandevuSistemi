using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class AdminLogin
    {
        [Key]
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
