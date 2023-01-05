using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public CreateModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var listaServiciu = _context.Serviciu
            .Include(b => b.Medic)
            .Select(x => new
            {
                x.ID,
                ServiciuFullName = x.Titlu + " - " + x.Medic.Prenume + " " +
                x.Medic.Nume
            });
            ViewData["ServiciuID"] = new SelectList(listaServiciu, "ID", "ServiciuFullName");
            ViewData["PacientID"] = new SelectList(_context.Pacient, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
