using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Specialitati
{
    public class IndexModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public IndexModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        public IList<Specialitate> Specialitate { get; set; } = default!;
        public SpecialitateIndexData SpecialitateData { get; set; }
        public int SpecialitateID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            SpecialitateData = new SpecialitateIndexData();
            SpecialitateData.Specialitati = await _context.Specialitate
            .Include(i => i.SpecialitatiServiciu)
            .ThenInclude(i => i.Serviciu)
            .ThenInclude(i => i.Medic)
            .OrderBy(i => i.NumeSpecialitate)
            .ToListAsync();
            if (id != null)
            {
                SpecialitateID = id.Value;
                Specialitate specialitate = SpecialitateData.Specialitati
                .Where(i => i.ID == id.Value).Single();
                SpecialitateData.SpecialitatiServiciu = specialitate.SpecialitatiServiciu;
            }
        }
    }
}
