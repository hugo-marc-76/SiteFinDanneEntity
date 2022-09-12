using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteFinAnnee2Entity;
using SiteFinAnnee2Entity.Data;
using SiteFinAnnee2Entity.Models;

namespace SiteFinAnnee2Entity.Areas.CarEvent.Pages
{
    public class EditModel : PageModel
    {
        private readonly SiteFinAnnee2Entity.Data.ApplicationDbContext _context;

        public EditModel(SiteFinAnnee2Entity.Data.ApplicationDbContext context)
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

            var eventcarmodel =  await _context.EventCarModel.FirstOrDefaultAsync(m => m.Id == id);
            if (eventcarmodel == null)
            {
                return NotFound();
            }
            EventCarModel = eventcarmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventCarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCarModelExists(EventCarModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventCarModelExists(int id)
        {
          return (_context.EventCarModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
