using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }
        public string? SocialName { get; set; }
        public string? SocialLink { get; set; }
    }
}
