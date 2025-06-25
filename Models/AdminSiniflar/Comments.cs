using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Comments
    {
        [Key]
        public int CommentsID { get; set; }
        public string? Description1 { get; set; }
        public string? COmmentsName { get; set; }
        public string? Description2 { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
    }
}
