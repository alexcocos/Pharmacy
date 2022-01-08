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
    public class DetailsModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public DetailsModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

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
    }
}
