using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todean_Olaeriu.Data;
using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Todean_Olaeriu.Data.Todean_OlaeriuContext _context;

        public IndexModel(Todean_Olaeriu.Data.Todean_OlaeriuContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;
        public DateServiciu ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int SpecialitateID { get; set; }
        public string SortareTitlu { get; set; }
        public string SortareMedic { get; set; }
        public string SortarePret { get; set; }
        public string Filtru { get; set; }


        public async Task OnGetAsync(int? id, int? specialitateID, string sortOrder, string searchString)
        {
            ServiciuD = new DateServiciu();
            SortareTitlu = String.IsNullOrEmpty(sortOrder) ? "titlu_asc" : "";
            SortareMedic = String.IsNullOrEmpty(sortOrder) ? "medic_asc" : "";
            SortarePret = String.IsNullOrEmpty(sortOrder) ? "pret_asc" : "";

            Filtru = searchString;

            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Medic)
            .Include(b => b.Orar)
            .Include(b => b.SpecialitatiServiciu)
            .ThenInclude(b => b.Specialitate)
            .AsNoTracking()
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Medic.Prenume.Contains(searchString)

               || s.Medic.Nume.Contains(searchString) || s.Titlu.Contains(searchString)) ;

            }
                if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Specialitati = serviciu.SpecialitatiServiciu.Select(s => s.Specialitate);
            }
            switch (sortOrder)
            {
                case "titlu_asc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s =>
                   s.Titlu);
                    break;
                case "medic_asc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s =>
                   s.Medic.FullName);
                    break;
                case "pret_asc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderBy(s =>
                   s.Pret);
                    break;
            }
        }
    }
}
