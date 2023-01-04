using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Pacienti
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
            return Page();
        }

        [BindProperty]
        public Pacient Pacient { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pacient.Add(Pacient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
