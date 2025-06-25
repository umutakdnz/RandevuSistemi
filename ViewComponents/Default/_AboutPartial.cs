using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;
using Microsoft.EntityFrameworkCore;

namespace RandevuSistemi.ViewComponents.Default
{
    public class _AboutPartial : ViewComponent
    {
        private readonly Context db;

        public _AboutPartial(Context context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await db.Abouts.ToListAsync();
            return View(values);
        }
    }
}
