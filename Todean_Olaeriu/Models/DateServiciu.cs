﻿namespace Todean_Olaeriu.Models
{
    public class DateServiciu
    {
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Specialitate> Specialitati { get; set; }
        public IEnumerable<SpecialitateServiciu> SpecialitatiServiciu { get; set; }
    }
}
