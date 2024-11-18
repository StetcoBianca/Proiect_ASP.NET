namespace Proiect_ASP.NET.Models
{
    public class CategorieFitness
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; } = string.Empty;

        public ICollection<ClasaCategorieFitness>? ClasaCategorieFitness { get; set; }
    }
}
