using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Models
{
    public class Forma
    {

        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Descriere { get; set; }
        public ICollection<Medicament> Medicamente { get; set; }
    }
}
