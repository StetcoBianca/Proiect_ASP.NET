using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP.NET.Data;
using Proiect_ASP.NET.Models;

namespace Proiect_ASP.NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_ASP.NET.Data.Proiect_ASPNETContext _context;

        public IndexModel(Proiect_ASP.NET.Data.Proiect_ASPNETContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Instructor = await _context.Instructor.ToListAsync();
        }
    }
}
