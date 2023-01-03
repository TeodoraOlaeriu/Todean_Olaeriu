using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Todean_Olaeriu.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        [Display(Name ="Denumire Investigatie")]
        public string Titlu { get; set; }
        public int? MedicID { get; set; }
        public Medic? Medic { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Preț")]
        public decimal Pret { get; set; }
        public int? OrarID { get; set; }
        public Orar? Orar { get; set; }
        [Display(Name = "Specialitate")]
        public ICollection<SpecialitateServiciu>? SpecialitatiServiciu { get; set; }
    }
}
