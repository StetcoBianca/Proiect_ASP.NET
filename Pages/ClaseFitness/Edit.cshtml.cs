using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.NET.Data;
using Proiect_ASP.NET.Models;

namespace Proiect_ASP.NET.Pages.ClaseFitness
{
    public class EditModel : PageModel
    {
        private readonly Proiect_ASP.NET.Data.Proiect_ASPNETContext _context;

        public EditModel(Proiect_ASP.NET.Data.Proiect_ASPNETContext context)
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

            var clasafitness = await _context.ClasaFitness.FirstOrDefaultAsync(m => m.ID == id);
            if (clasafitness == null)
            {
                return NotFound();
            }

            ClasaFitness = clasafitness;

            // Populează dropdown-ul pentru instructori
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "Nume");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Re-populează dropdown-ul în cazul unei erori de validare
                ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "Nume");
                return Page();
            }

            _context.Attach(ClasaFitness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasaFitnessExists(ClasaFitness.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClasaFitnessExists(int id)
        {
            return _context.ClasaFitness.Any(e => e.ID == id);
        }
    }
}
