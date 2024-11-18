using System.ComponentModel.DataAnnotations;

namespace Proiect_ASP.NET.Models
{
    public class ClasaFitness
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Numele clasei este obligatoriu.")]
        public string NumeClasa { get; set; } = string.Empty;

        [Required(ErrorMessage = "Orarul este obligatoriu.")]
        public string Orar { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Capacitatea trebuie să fie între 1 și 100.")]
        public int Capacitate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Clasei")]
        public DateTime Data { get; set; }

        public int? InstructorID { get; set; }
        public Instructor? Instructor { get; set; }


        public int? UtilizatorID { get; set; }
        public Utilizator? Utilizator { get; set; }

        public ICollection<ClasaCategorieFitness>? ClasaCategorieFitness { get; set; }



    }
}
