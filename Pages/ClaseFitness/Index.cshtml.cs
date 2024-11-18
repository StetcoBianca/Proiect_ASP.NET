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

        public IList<ClasaFitness> ClasaFitness { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ClasaFitness = await _context.ClasaFitness
                .Include(c => c.Instructor)
                .ToListAsync();
        }
    }
}
