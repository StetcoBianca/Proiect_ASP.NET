using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_ASP.NET.Data;
using Proiect_ASP.NET.Models;

namespace Proiect_ASP.NET.Pages.ClaseFitness
{
    public class CreateModel : CategorieFitnessPageModel
    {
        private readonly Proiect_ASP.NET.Data.Proiect_ASPNETContext _context;

        public CreateModel(Proiect_ASP.NET.Data.Proiect_ASPNETContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "Nume");

            var clasaFitness = new ClasaFitness
            {
                ClasaCategorieFitness = new List<ClasaCategorieFitness>()
            };
            PopulateAssignedCategorieData(_context, clasaFitness);

            return Page();
        }

        [BindProperty]
        public ClasaFitness ClasaFitness { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newClasaFitness = new ClasaFitness
            {
                ClasaCategorieFitness = new List<ClasaCategorieFitness>()
            };

            if (selectedCategories != null)
            {
                foreach (var cat in selectedCategories)
                {
                    var categoryToAdd = new ClasaCategorieFitness
                    {
                        CategorieFitnessID = int.Parse(cat)
                    };
                    newClasaFitness.ClasaCategorieFitness.Add(categoryToAdd);
                }
            }

            ClasaFitness.ClasaCategorieFitness = newClasaFitness.ClasaCategorieFitness;

            _context.ClasaFitness.Add(ClasaFitness);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}