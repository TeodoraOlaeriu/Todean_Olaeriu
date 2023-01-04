using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : SpecialitatiServiciuPageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public CreateModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var medicList = _context.Medic.Select(x => new
            {
                x.ID,
                FullName = x.Prenume + " " + x.Nume
            });
            ViewData["MedicID"] = new SelectList(medicList, "ID", "FullName");
            ViewData["OrarID"] = new SelectList(_context.Set<Orar>(), "ID", "Zi");
            var serviciu = new Serviciu();
            serviciu.SpecialitatiServiciu = new List<SpecialitateServiciu>();
            PopulareDateSpecialitateAtribuite(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] specialitatiSelectate)
        {
            var serviciuNou = new Serviciu();
            if (specialitatiSelectate != null)
            {
                serviciuNou.SpecialitatiServiciu = new List<SpecialitateServiciu>();
                foreach (var sp in specialitatiSelectate)
                {
                    var spToAdd = new SpecialitateServiciu
                    {
                        SpecialitateID = int.Parse(sp)
                    };
                    serviciuNou.SpecialitatiServiciu.Add(spToAdd);
                }
            }
            Serviciu.SpecialitatiServiciu = serviciuNou.SpecialitatiServiciu;
            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulareDateSpecialitateAtribuite(_context, serviciuNou);
            return Page();
        }
    }
}
