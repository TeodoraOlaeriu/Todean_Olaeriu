using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Pacienti
{
    public class DetailsModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public DetailsModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

      public Pacient Pacient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pacient == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacient.FirstOrDefaultAsync(m => m.ID == id);
            if (pacient == null)
            {
                return NotFound();
            }
            else 
            {
                Pacient = pacient;
            }
            return Page();
        }
    }
}
