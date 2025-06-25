using System.ComponentModel.DataAnnotations;

namespace RandevuSistemi.Models.AdminSiniflar
{
    public class Category
    {
        public Category()
        {
            this.Price = new HashSet<Price>();
        }

        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<Price> Price { get; set; }
    }
}
