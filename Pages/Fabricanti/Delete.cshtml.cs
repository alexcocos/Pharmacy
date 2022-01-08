using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Fabricanti
{
    public class DeleteModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public DeleteModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fabricant Fabricant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Fabricant = await _context.Fabricant.FirstOrDefaultAsync(m => m.ID == id);

            if (Fabricant == null)
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

            Fabricant = await _context.Fabricant.FindAsync(id);

            if (Fabricant != null)
            {
                _context.Fabricant.Remove(Fabricant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
