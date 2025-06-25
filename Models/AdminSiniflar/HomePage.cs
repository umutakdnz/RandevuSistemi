using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class HomePage
    {
        [Key]
        public int HomePageID { get; set; }
        public string? NameSurname { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
