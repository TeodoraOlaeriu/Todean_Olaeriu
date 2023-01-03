using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Todean_Olaeriu.Models
{
    public class Orar
    {
        public int ID { get; set; }
        [Display(Name = "Program")]
        public string Zi { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
