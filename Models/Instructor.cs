using System.ComponentModel.DataAnnotations;

namespace Proiect_ASP.NET.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Display(Name = "Nume Instructor")]
        public string Nume { get; set; } = string.Empty;

        [Display(Name = "Specializare")]
        public string Specializare { get; set; } = string.Empty;
    }
}
