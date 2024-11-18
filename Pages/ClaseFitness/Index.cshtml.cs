using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.NET.Data;
using Proiect_ASP.NET.Models;

namespace Proiect_ASP.NET.Pages.ClaseFitness
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_ASP.NET.Data.Proiect_ASPNETContext _context;

        public IndexModel(Proiect_ASP.NET.Data.Proiect_ASPNETContext context)
        {
            _context = context;
        }

        public IList<ClasaFitness> ClasaFitness { get; set; } = new List<ClasaFitness>();
        public ClasaFitnessData ClasaFitnessD { get; set; }
        public int ClasaFitnessID { get; set; }
        public int CategorieFitnessID { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ClasaFitnessD = new ClasaFitnessData
            {
                ClaseFitness = await _context.ClasaFitness
                    .Include(c => c.Instructor)
                    .Include(c => c.ClasaCategorieFitness)
                    .ThenInclude(cc => cc.CategorieFitness)
                    .AsNoTracking()
                    .OrderBy(c => c.NumeClasa)
                    .ToListAsync()
            };

            if (id != null)
            {
                ClasaFitnessID = id.Value;
                ClasaFitness clasaFitness = ClasaFitnessD.ClaseFitness
                    .Where(c => c.ID == id.Value).Single();

                ClasaFitnessD.CategoriiFitness = clasaFitness.ClasaCategorieFitness
                    .Select(cc => cc.CategorieFitness);
            }
        }
    }
}
