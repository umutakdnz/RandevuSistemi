using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Services
    {
        [Key]
        public int ServicesID { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? IconUrl { get; set; }
        public string? Description2 { get; set; }
    }
}
