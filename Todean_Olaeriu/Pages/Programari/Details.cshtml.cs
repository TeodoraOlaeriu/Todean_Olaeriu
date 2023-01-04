using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Programari
{
    public class DetailsModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public DetailsModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

      public Programare Programare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            var programare = await _context.Programare.Include(b => b.Pacient).Include(b => b.Serviciu).ThenInclude(b => b.Medic).FirstOrDefaultAsync(m => m.ID == id);
            if (programare == null)
            {
                return NotFound();
            }
            else 
            {
                Programare = programare;
            }
            return Page();
        }
    }
}
