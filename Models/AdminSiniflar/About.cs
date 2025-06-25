using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string? ImgUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FoundedYear  { get; set; }
        public string? Address  { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Person { get; set; }
    }
}
