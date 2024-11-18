using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_ASP.NET.Data;

namespace Proiect_ASP.NET.Models
{
    public class CategorieFitnessPageModel : PageModel
    {
        public List<AssignedCategorieData> AssignedCategorieDataList { get; set; } = new();

        public void PopulateAssignedCategorieData(Proiect_ASPNETContext context, ClasaFitness clasaFitness)
        {
            var allCategories = context.CategoriiFitness;
            var fitnessCategories = new HashSet<int>(
                clasaFitness.ClasaCategorieFitness?.Select(c => c.CategorieFitnessID) ?? new List<int>());

            AssignedCategorieDataList = allCategories.Select(cat => new AssignedCategorieData
            {
                CategorieID = cat.ID,
                Nume = cat.NumeCategorie,
                Assigned = fitnessCategories.Contains(cat.ID)
            }).ToList();
        }

        public void UpdateFitnessCategories(Proiect_ASPNETContext context, string[] selectedCategories, ClasaFitness clasaToUpdate)
        {
            if (selectedCategories == null)
            {
                clasaToUpdate.ClasaCategorieFitness = new List<ClasaCategorieFitness>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var currentCategories = new HashSet<int>(
                clasaToUpdate.ClasaCategorieFitness.Select(c => c.CategorieFitnessID));

            foreach (var category in context.CategoriiFitness)
            {
                if (selectedCategoriesHS.Contains(category.ID.ToString()))
                {
                    if (!currentCategories.Contains(category.ID))
                    {
                        clasaToUpdate.ClasaCategorieFitness.Add(new ClasaCategorieFitness
                        {
                            ClasaFitnessID = clasaToUpdate.ID,
                            CategorieFitnessID = category.ID
                        });
                    }
                }
                else
                {
                    if (currentCategories.Contains(category.ID))
                    {
                        var categoryToRemove = clasaToUpdate.ClasaCategorieFitness
                            .FirstOrDefault(c => c.CategorieFitnessID == category.ID);
                        if (categoryToRemove != null)
                        {
                            context.ClaseCategoriiFitness.Remove(categoryToRemove);
                        }
                    }
                }
            }
        }
    }
}
