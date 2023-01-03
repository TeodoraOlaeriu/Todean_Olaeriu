using System.Security.Policy;
using Todean_Olaeriu.Models;
namespace Todean_Olaeriu.Models.ViewModels
{
    public class OrarIndexData
    {
        public IEnumerable<Orar> Orare { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }
    }
}
