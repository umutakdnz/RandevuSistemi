using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.ViewComponents.Default
{
    public class _HomePagePartial : ViewComponent
    {
        private readonly Context db;

        public _HomePagePartial(Context context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await db.HomePages.ToListAsync();
            return View(values);
        }
    }
}
