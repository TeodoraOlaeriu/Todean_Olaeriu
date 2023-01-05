using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Programari
{
    public class EditModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public EditModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare{ get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            var programare = await _context.Programare.FirstOrDefaultAsync(m => m.ID == id);
            if (programare == null)
            {
                return NotFound();
            }
            Programare = programare;
            var listaServiciu = _context.Serviciu
            .Include(b => b.Medic)
            .Select(x => new
            {
                x.ID,
                SerivciuFullName = x.Titlu + " - " + x.Medic.Nume + " " +
                x.Medic.Prenume
            });
            ViewData["ServiciuID"] = new SelectList(listaServiciu, "ID", "SerivciuFullName");
            ViewData["PacientID"] = new SelectList(_context.Pacient, "ID", "FullName");
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

            _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.ID))
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

        private bool ProgramareExists(int id)
        {
            return _context.Programare.Any(e => e.ID == id);
        }
    }
}
