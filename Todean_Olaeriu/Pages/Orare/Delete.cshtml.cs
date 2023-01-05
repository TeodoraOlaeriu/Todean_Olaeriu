using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Orare
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
      public Orar Orar { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orar == null)
            {
                return NotFound();
            }

            var orar = await _context.Orar.FirstOrDefaultAsync(m => m.ID == id);

            if (orar == null)
            {
                return NotFound();
            }
            else 
            {
                Orar = orar;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Orar == null)
            {
                return NotFound();
            }
            var orar = await _context.Orar.FindAsync(id);

            if (orar != null)
            {
                Orar = orar;
                _context.Orar.Remove(Orar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
