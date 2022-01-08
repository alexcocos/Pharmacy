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
    public class IndexModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public IndexModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        public IList<Medicament> Medicament { get;set; }

        public async Task OnGetAsync()
        {
            Medicament = await _context.Medicament.Include(b => b.Forma).Include(b => b.Administrare).Include(b => b.Fabricant).Include(b => b.Categorie).ToListAsync();
        }
    }
}
