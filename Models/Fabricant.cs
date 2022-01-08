using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Fabricant
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public ICollection<Medicament> Medicamente { get; set; }
    }
}
