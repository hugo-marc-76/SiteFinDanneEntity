using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteFinAnnee2Entity.Data;
using SiteFinAnnee2Entity.Models;
using SiteFinAnnee2Entity.Services;

namespace SiteFinAnnee2Entity.Areas.CarEvent.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageService _imageService;

        public CreateModel(ApplicationDbContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EventCarModel EventCarModel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          
            var emptyCarEvent = new EventCarModel();

            if(null != EventCarModel.Image)
                emptyCarEvent.Image = await _imageService.uploadAsync(EventCarModel.Image);

            if(await TryUpdateModelAsync(emptyCarEvent, "EventCarModel", c => c.Title, c => c.Description, c => c.Image, c => c.Created, c => c.Start, c => c.End, c => c.Location))
            {
                _context.EventCarModel.Add(emptyCarEvent);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
            
        }
    }
}
