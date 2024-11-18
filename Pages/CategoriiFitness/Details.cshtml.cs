using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.NET.Data;
using Proiect_ASP.NET.Models;

namespace Proiect_ASP.NET.Pages.CategoriiFitness
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_ASP.NET.Data.Proiect_ASPNETContext _context;

        public DetailsModel(Proiect_ASP.NET.Data.Proiect_ASPNETContext context)
        {
            _context = context;
        }

        public CategorieFitness CategorieFitness { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriefitness = await _context.CategoriiFitness.FirstOrDefaultAsync(m => m.ID == id);
            if (categoriefitness == null)
            {
                return NotFound();
            }
            else
            {
                CategorieFitness = categoriefitness;
            }
            return Page();
        }
    }
}
