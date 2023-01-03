using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Orare
{
    public class DetailsModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public DetailsModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

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
    }
}
