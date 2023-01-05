using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Specialitati
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public DeleteModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Specialitate == null)
            {
                return NotFound();
            }
            var specialitate = await _context.Specialitate.FindAsync(id);

            if (specialitate != null)
            {
                Specialitate = specialitate;
                _context.Specialitate.Remove(Specialitate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
