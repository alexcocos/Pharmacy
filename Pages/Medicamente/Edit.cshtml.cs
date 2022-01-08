using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Medicamente
{
    public class EditModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public EditModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medicament Medicament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicament = await _context.Medicament.FirstOrDefaultAsync(m => m.ID == id);

            if (Medicament == null)
            {
                return NotFound();
            }
            ViewData["FormaID"] = new SelectList(_context.Set<Forma>(), "ID", "Denumire");
            ViewData["AdministrareID"] = new SelectList(_context.Set<Administrare>(), "ID", "Denumire");
            ViewData["FabricantID"] = new SelectList(_context.Set<Fabricant>(), "ID", "Nume");
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "Denumire");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Medicament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentExists(Medicament.ID))
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

        private bool MedicamentExists(int id)
        {
            return _context.Medicament.Any(e => e.ID == id);
        }
    }
}
