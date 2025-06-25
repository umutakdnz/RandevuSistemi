using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Price //FİYATLAR VE MODELLER
    {
        [Key]
        public int PriceID { get; set; }
        public string? PriceName { get; set; }
        public string? Description { get; set; }
        public string? PriceLink { get; set; }
        public string? Image1 { get; set; }
        public Nullable<int> CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
