using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SiteFinAnnee2Entity;
using SiteFinAnnee2Entity.Data;
using SiteFinAnnee2Entity.Models;

namespace SiteFinAnnee2Entity.Areas.CarEvent.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EventCarModel> EventCarModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EventCarModel != null)
            {
                EventCarModel = await _context.EventCarModel.Include(f => f.Image).ToListAsync();
            }
        }
    }
}
