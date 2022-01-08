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
    public class IndexModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public IndexModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        public IList<Fabricant> Fabricant { get;set; }

        public async Task OnGetAsync()
        {
            Fabricant = await _context.Fabricant.ToListAsync();
        }
    }
}
