using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using utulek_2.Model;

namespace utulek_2
{
    internal class Evidence
    {
        public static void ZobrazSeznam(IEnumerable<Model.Zvire> zvirata)
        {
            if (zvirata == null || !zvirata.Any())
            {
                Console.WriteLine("V útulku momentálně nejsou žádná zvířata.");
                return;
            }

            Console.WriteLine("\n{0,-4} {1,-12} {2,-8} {3,-4} {4,-8} {5,-12} {6,-10} {7}",
                "ID", "Jméno", "Druh", "Věk", "Pohlaví", "Příjem", "Adopce", "Poznámka");
            Console.WriteLine(new string('-', 80));

            foreach (var z in zvirata)
            {
                Console.WriteLine("{0,-4} {1,-12} {2,-8} {3,3}  {4,-8} {5:dd.MM.yyyy} {6,-10} {7}",
                    z.ID,
                    z.Jméno?.Length > 12 ? z.Jméno.Substring(0, 12) : z.Jméno,
                    z.Druh,
                    z.Věk,
                    z.Pohlaví,
                    z.DatumPříjmu,
                    z.Adoptováno ? $"✓ {z.DatumAdopce:dd.MM.yyyy}" : "—",
                    z.Poznámka);
            }
            Console.WriteLine();
        }
        
    }
}

