namespace Proiect_ASP.NET.Models
{
    public class ClasaCategorieFitness
    {
        public int ID { get; set; }
        public int ClasaFitnessID { get; set; }
        public ClasaFitness ClasaFitness { get; set; } = default!;

        public int CategorieFitnessID { get; set; }
        public CategorieFitness CategorieFitness { get; set; } = default!;
    }
}
