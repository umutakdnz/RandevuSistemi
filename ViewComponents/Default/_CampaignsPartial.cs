using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.ViewComponents.Default
{
    public class _CampaignsPartial : ViewComponent
    {
        private readonly Context db;

        public _CampaignsPartial(Context context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await db.Campaigns.ToListAsync();
            return View(values);
        }
    }
}
