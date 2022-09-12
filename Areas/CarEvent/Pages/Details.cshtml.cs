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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public EventCarModel EventCarModel { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventCarModel == null)
            {
                return NotFound();
            }

            var eventcarmodel = await _context.EventCarModel.Include(f => f.Image).FirstOrDefaultAsync(m => m.Id == id);
            if (eventcarmodel == null)
            {
                return NotFound();
            }
            else 
            {
                EventCarModel = eventcarmodel;
            }
            return Page();
        }
    }
}
