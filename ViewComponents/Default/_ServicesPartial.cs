using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.ViewComponents.Default
{
    public class _ServicesPartial : ViewComponent
    {
        private readonly Context db;
        
        public _ServicesPartial(Context context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await db.Services.ToListAsync();
            return View(values);
        }
    }
}
