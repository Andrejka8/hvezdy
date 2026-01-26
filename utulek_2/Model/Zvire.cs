using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utulek_2.Model
{
    internal class Zvire
    {
        public int ID { get; set; } // automaticky generované
        public string Jméno { get; set; } = string.Empty;
        public string Druh { get; set; } = string.Empty; // pes/kočka/jiné
        public int Věk { get; set; } // roky
        public string Pohlaví { get; set; } = string.Empty;
        public DateTime DatumPříjmu { get; set; } = DateTime.Today;
        public string ZdravStav { get; set; } = string.Empty;
        public string Poznámka { get; set; } = string.Empty;

        public bool Adoptováno { get; set; }
        public DateTime? DatumAdopce { get; set; }
        
    }
}

