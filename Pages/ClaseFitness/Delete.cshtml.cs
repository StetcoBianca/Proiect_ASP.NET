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
    public class DeleteModel : PageModel
    {
        private readonly Proiect_ASP.NET.Data.Proiect_ASPNETContext _context;

        public DeleteModel(Proiect_ASP.NET.Data.Proiect_ASPNETContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClasaFitness ClasaFitness { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasafitness = await _context.ClasaFitness
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (clasafitness == null)
            {
                return NotFound();
            }
            else
            {
                ClasaFitness = clasafitness;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasafitness = await _context.ClasaFitness.FindAsync(id);
            if (clasafitness != null)
            {
                ClasaFitness = clasafitness;
                _context.ClasaFitness.Remove(ClasaFitness);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
