using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Specialitati
{
    public class DetailsModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public DetailsModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

      public Specialitate Specialitate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specialitate == null)
            {
                return NotFound();
            }

            var specialitate = await _context.Specialitate.FirstOrDefaultAsync(m => m.ID == id);
            if (specialitate == null)
            {
                return NotFound();
            }
            else 
            {
                Specialitate = specialitate;
            }
            return Page();
        }
    }
}
