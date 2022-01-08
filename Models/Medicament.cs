using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models
{
    public class Medicament
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public decimal Gramaj { get; set; }
        public int FormaID { get; set; }
        public Forma Forma { get; set; }
        public int AdministrareID { get; set; }
        public Administrare Administrare { get; set; }
        
        public decimal Pret { get; set; }
        
        public int FabricantID { get; set; }
        public Fabricant Fabricant { get; set; }
        public int CategorieID { get; set;}
        public Categorie Categorie { get; set; }

    }
}
