using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.ViewComponents.Default
{
    public class _PricePartial : ViewComponent
    {
        private readonly Context db;

        public _PricePartial(Context context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await db.Prices.ToListAsync();
            return View(values);
        }
    }
}
