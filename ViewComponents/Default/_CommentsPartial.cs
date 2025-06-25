using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.ViewComponents.Default
{
    public class _CommentsPartial : ViewComponent
    {
        private readonly Context db;
        public _CommentsPartial(Context context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await db.Comments.ToListAsync();
            return View(values);
        }
    }
}
