using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Messages
    {
        [Key]
        public int MessagesID { get; set; }
        public string? NameSurname { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? MessageContent { get; set; }
    }
}
