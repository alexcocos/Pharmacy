using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Administrari
{
    public class CreateModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public CreateModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Administrare Administrare { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Administrare.Add(Administrare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
