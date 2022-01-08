using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Pharmacy.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext (DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacy.Models.Medicament> Medicament { get; set; }

        public DbSet<Pharmacy.Models.Forma> Forma { get; set; }

        public DbSet<Pharmacy.Models.Administrare> Administrare { get; set; }

        public DbSet<Pharmacy.Models.Fabricant> Fabricant { get; set; }

        public DbSet<Pharmacy.Models.Categorie> Categorie { get; set; }
    }
}
