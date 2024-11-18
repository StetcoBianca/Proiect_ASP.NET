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
    public class EditModel : CategorieFitnessPageModel
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

            var clasafitness = await _context.ClasaFitness
                .Include(c => c.ClasaCategorieFitness)
                .ThenInclude(cc => cc.CategorieFitness)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (clasafitness == null)
            {
                return NotFound();
            }

            ClasaFitness = clasafitness;

            PopulateAssignedCategorieData(_context, ClasaFitness);

            // Populează dropdown-ul pentru instructori
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "Nume");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clasaToUpdate = await _context.ClasaFitness
                .Include(c => c.ClasaCategorieFitness)
                .ThenInclude(cc => cc.CategorieFitness)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (clasaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ClasaFitness>(
                clasaToUpdate,
                "ClasaFitness",
                c => c.NumeClasa, c => c.Orar, c => c.Capacitate, c => c.Data, c => c.InstructorID))
            {
                // Update categories based on selected checkboxes
                UpdateFitnessCategories(_context, selectedCategories, clasaToUpdate);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Repopulate dropdowns and checkbox data in case of error
            PopulateAssignedCategorieData(_context, clasaToUpdate);
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "Nume");
            return Page();
        }
    }
}