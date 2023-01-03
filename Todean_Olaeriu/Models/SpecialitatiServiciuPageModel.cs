using Microsoft.AspNetCore.Mvc.RazorPages;
using Todean_Olaeriu.Data;
namespace Todean_Olaeriu.Models
{
    public class SpecialitatiServiciuPageModel : PageModel
    {
        public List<DateSpecialitateAtribuite> ListaDateSpecialitateAtribuite;
        public void PopulareDateSpecialitateAtribuite(Todean_OlaeriuContext context, Serviciu serviciu)
        {
            var toateSpecialitatile = context.Specialitate;
            var specialitatiServiciu = new HashSet<int>(
            serviciu.SpecialitatiServiciu.Select(c => c.SpecialitateID));
            ListaDateSpecialitateAtribuite = new List<DateSpecialitateAtribuite>();
            foreach (var sp in toateSpecialitatile)
            {
                ListaDateSpecialitateAtribuite.Add(new DateSpecialitateAtribuite
                {
                    SpecialitateID = sp.ID,
                    Nume = sp.NumeSpecialitate,
                    Atribuit = specialitatiServiciu.Contains(sp.ID)
                });
            }
        }
        public void UpdateSpecialitatiServiciu(Todean_OlaeriuContext context,string[] categoriiSelectate, Serviciu serviciuToUpdate)
        {
            if (categoriiSelectate == null)
            {
                serviciuToUpdate.SpecialitatiServiciu = new List<SpecialitateServiciu>();
                return;
            }
            var categoriiSelectateHS = new HashSet<string>(categoriiSelectate);
            var specialitatiServiciu = new HashSet<int>
            (serviciuToUpdate.SpecialitatiServiciu.Select(c => c.Specialitate.ID));
            foreach (var sp in context.Specialitate)
            {
                if (categoriiSelectateHS.Contains(sp.ID.ToString()))
                {
                    if (!specialitatiServiciu.Contains(sp.ID))
                    {
                        serviciuToUpdate.SpecialitatiServiciu.Add(
                        new SpecialitateServiciu
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            SpecialitateID = sp.ID
                        });
                    }
                }
                else
                {
                    if (specialitatiServiciu.Contains(sp.ID))
                    {
                        SpecialitateServiciu courseToRemove
                        = serviciuToUpdate
                        .SpecialitatiServiciu
                        .SingleOrDefault(i => i.SpecialitateID == sp.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
