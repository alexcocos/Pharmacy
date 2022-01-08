using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Medicamente
{
    public class DeleteModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public DeleteModel(Pharmacy.Data.PharmacyContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medicament = await _context.Medicament.FindAsync(id);

            if (Medicament != null)
            {
                _context.Medicament.Remove(Medicament);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
