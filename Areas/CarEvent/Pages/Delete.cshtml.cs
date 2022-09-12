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
    public class DeleteModel : PageModel
    {
        private readonly SiteFinAnnee2Entity.Data.ApplicationDbContext _context;

        public DeleteModel(SiteFinAnnee2Entity.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EventCarModel EventCarModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventCarModel == null)
            {
                return NotFound();
            }

            var eventcarmodel = await _context.EventCarModel.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EventCarModel == null)
            {
                return NotFound();
            }
            var eventcarmodel = await _context.EventCarModel.FindAsync(id);

            if (eventcarmodel != null)
            {
                EventCarModel = eventcarmodel;
                _context.EventCarModel.Remove(EventCarModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
