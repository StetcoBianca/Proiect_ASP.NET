namespace Proiect_ASP.NET.Models
{
    public class ClasaFitnessData
    {
        public IEnumerable<ClasaFitness> ClaseFitness { get; set; }
        public IEnumerable<CategorieFitness> CategoriiFitness { get; set; }
        public IEnumerable<ClasaCategorieFitness> ClaseCategoriiFitness { get; set; }
    }
}
