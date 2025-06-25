using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class CustomerComment
    {
        [Key]
        public int CustomerCommentID { get; set; }
        public string? CustomerName { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public int BarberId { get; set; } // Foreign Key
        public Barber Barber { get; set; }
    }
}
