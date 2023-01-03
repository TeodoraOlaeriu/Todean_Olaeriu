using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Servicii
{
    public class EditModel : SpecialitatiServiciuPageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public EditModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }
            Serviciu = await _context.Serviciu
                     .Include(b => b.Orar)
                     .Include(b => b.SpecialitatiServiciu).ThenInclude(b => b.Specialitate)
                     .AsNoTracking()
                     .FirstOrDefaultAsync(m => m.ID == id);
            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            PopulareDateSpecialitateAtribuite(_context, Serviciu);
            Serviciu = serviciu;
            var medicList = _context.Medic.Select(x => new
            {
                x.ID,
                FullName = x.Prenume + " " + x.Nume
            });
            ViewData["MedicID"] = new SelectList(medicList, "ID", "FullName");
            ViewData["OrarID"] = new SelectList(_context.Set<Orar>(), "ID", "Zi");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] categoriiSelectate)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviciuToUpdate = await _context.Serviciu
            .Include(i => i.Orar)
            .Include(i => i.SpecialitatiServiciu)
            .ThenInclude(i => i.Specialitate)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviciuToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Titlu, i => i.Medic,
            i => i.Pret, i => i.OrarID))
            {
                UpdateSpecialitatiServiciu(_context, categoriiSelectate, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateSpecialitatiServiciu(_context, categoriiSelectate, serviciuToUpdate);
            PopulareDateSpecialitateAtribuite(_context, serviciuToUpdate);
            return Page();
        }
    }
}
