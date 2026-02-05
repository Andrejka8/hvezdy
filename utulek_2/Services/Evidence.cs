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
        private static List<Zvire> _seznamZvirat = new List<Zvire>();
        private static int _posledniId = 0;

        // Metoda pro přidání zvířete (voláno z UI)
        public static void Pridej(Zvire zvire)
        {
            _posledniId++;
            zvire.ID = _posledniId;
            zvire.DatumPříjmu = DateTime.Now;
            _seznamZvirat.Add(zvire);
            Console.WriteLine("Zvíře bylo úspěšně přidáno.");
        }

        // Vrátí kopii seznamu všech zvířat
        public static IEnumerable<Zvire> VratVsechny()
        {
            return _seznamZvirat;
        }

        // --- FILTRAČNÍ METODY ---

        public static IEnumerable<Zvire> FiltrDruh(string druh)
        {
            return _seznamZvirat
                .Where(z => z.Druh.ToLower().Contains(druh.ToLower()));
        }

        public static IEnumerable<Zvire> FiltrVek(int vek, bool mensiNeboRovno)
        {
            if (mensiNeboRovno)
                return _seznamZvirat.Where(z => z.Věk <= vek);
            else
                return _seznamZvirat.Where(z => z.Věk >= vek);
        }

        public static IEnumerable<Zvire> FiltrJmeno(string castJmena)
        {
            return _seznamZvirat
                .Where(z => z.Jméno.ToLower().Contains(castJmena.ToLower()));
        }

        // --- ADOPCE A STATISTIKY ---

        public static bool OznacAdopci(int id)
        {
            var zvire = _seznamZvirat.FirstOrDefault(z => z.ID == id);

            if (zvire != null && !zvire.Adoptováno)
            {
                zvire.Adoptováno = true;
                zvire.DatumAdopce = DateTime.Now;
                return true;
            }
            return false;
        }

        public static void VypisStatistiky()
        {
            if (!_seznamZvirat.Any())
            {
                Console.WriteLine("Žádná data pro statistiku.");
                return;
            }

            Console.WriteLine("\n--- STATISTIKY ---");
            Console.WriteLine($"Celkem zvířat: {_seznamZvirat.Count}");
            Console.WriteLine($"Z toho adoptováno: {_seznamZvirat.Count(z => z.Adoptováno)}");
            Console.WriteLine($"Průměrný věk: {_seznamZvirat.Average(z => z.Věk):F1} let");

            // Seskupení podle druhu
            var podleDruhu = _seznamZvirat.GroupBy(z => z.Druh)
                                          .Select(g => new { Druh = g.Key, Pocet = g.Count() });

            Console.WriteLine("Počty dle druhu:");
            foreach (var item in podleDruhu)
            {
                Console.WriteLine($" - {item.Druh}: {item.Pocet}");
            }
        }

        // --- TVOJE PŮVODNÍ METODA PRO VÝPIS ---
        public static void ZobrazSeznam(IEnumerable<Zvire> zvirata)
        {
            if (zvirata == null || !zvirata.Any())
            {
                Console.WriteLine("V útulku momentálně nejsou žádná zvířata (nebo žádná neodpovídají filtru).");
                return;
            }

            Console.WriteLine("\n{0,-4} {1,-12} {2,-8} {3,-4} {4,-8} {5,-12} {6,-10} {7}",
                "ID", "Jméno", "Druh", "Věk", "Pohlaví", "Příjem", "Adopce", "Poznámka"); 
            Console.WriteLine(new string('-', 90));

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
        


