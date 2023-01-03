using Todean_Olaeriu.Models;

namespace Todean_Olaeriu.Pages.Specialitati
{
    public class SpecialitateIndexData
    {
        public List<Specialitate> Specialitati { get; internal set; }
        public ICollection<SpecialitateServiciu>? SpecialitatiServiciu { get; internal set; }
    }
}