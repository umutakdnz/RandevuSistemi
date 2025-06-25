using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string? Description { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
