using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Medicamente
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
            ViewData["FormaID"] = new SelectList(_context.Set<Forma>(), "ID", "Denumire");
            ViewData["AdministrareID"] = new SelectList(_context.Set<Administrare>(), "ID", "Denumire");
            ViewData["FabricantID"] = new SelectList(_context.Set<Fabricant>(), "ID", "Nume");
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Medicament Medicament { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Medicament.Add(Medicament);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
