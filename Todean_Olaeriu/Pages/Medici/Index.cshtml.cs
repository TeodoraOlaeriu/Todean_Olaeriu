using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Medici
{
    public class IndexModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public IndexModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        public IList<Medic> Medic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Medic != null)
            {
                Medic = await _context.Medic.ToListAsync();
            }
        }
    }
}
