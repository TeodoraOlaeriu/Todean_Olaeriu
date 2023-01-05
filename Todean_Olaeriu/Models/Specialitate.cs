using System.ComponentModel.DataAnnotations;

namespace Todean_Olaeriu.Models
{
    public class Specialitate
    {
        public int ID { get; set; }
        [Display(Name = "Specialitate")]
        public string NumeSpecialitate { get; set; }
        public ICollection<SpecialitateServiciu>? SpecialitatiServiciu { get; set; }
    }
}
