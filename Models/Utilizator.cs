using System.ComponentModel.DataAnnotations;

namespace Proiect_ASP.NET.Models
{
    public class Utilizator
    {
        public int ID { get; set; }

        [Display(Name = "Nume")]
        public string Nume { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tip Utilizator")]
        public string TipUtilizator { get; set; } // Admin/Client
    }

}
