// UI/KonzoleUI.cs
using System;
using utulek_2.Services;

namespace utulek_2.UI
{
    public static class KonzoleUI
    {
        public static void HlavniMenu()
        {
            while (true)
            {
                Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("3) Vyhledat/ filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("5) Statistiky (volitelné)");
                Console.WriteLine("0) Konec");
                Console.Write("Volba: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Evidence.Pridej(NactiZvire());
                        break;

                    case "2":
                        Evidence.ZobrazSeznam(Evidence.VratVsechny());
                        break;

                    case "3":
                        PodMenuFiltr();
                        break;

                    case "4":
                        OznačAdopci();
                        break;

                    case "5":
                        Evidence.VypisStatistiky();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }

                // oddělovač mezi jednotlivými akcemi
                Console.WriteLine(new string('-', 30));
            }
        }

        /* ---------- pomocné metody ---------- */

        private static Model.Zvire NactiZvire()
        {
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine() ?? "";

            Console.Write("Druh (pes/kočka/jiné): ");
            string druh = Console.ReadLine() ?? "";

            Console.Write("Věk (roky): ");
            int vek = int.TryParse(Console.ReadLine(), out int v) && v >= 0 ? v : 0;

            Console.Write("Pohlaví: ");
            string pohl = Console.ReadLine() ?? "";

            Console.Write("Zdravotní stav: ");
            string zdrav = Console.ReadLine() ?? "";

            Console.Write("Poznámka: ");
            string pozn = Console.ReadLine() ?? "";

            return new Model.Zvire
            {
                Jméno = jmeno,
                Druh = druh,
                Věk = vek,
                Pohlaví = pohl,
                ZdravStav = zdrav,
                Poznámka = pozn
            };
        }

        private static void PodMenuFiltr()
        {
            Console.Write("Filtrovat podle (1-druh, 2-věk ≤, 3-věk ≥, 4-jméno): ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Druh: ");
                    Evidence.ZobrazSeznam(Evidence.FiltrDruh(Console.ReadLine() ?? ""));
                    break;
                case "2":
                    Console.Write("Věk ≤: ");
                    if (int.TryParse(Console.ReadLine(), out int vekLe)) Evidence.ZobrazSeznam(Evidence.FiltrVek(vekLe, true));
                    break;
                case "3":
                    Console.Write("Věk ≥: ");
                    if (int.TryParse(Console.ReadLine(), out int vekGe)) Evidence.ZobrazSeznam(Evidence.FiltrVek(vekGe, false));
                    break;
                case "4":
                    Console.Write("Část jména: ");
                    Evidence.ZobrazSeznam(Evidence.FiltrJmeno(Console.ReadLine() ?? ""));
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }

        private static void OznačAdopci()
        {
            Console.Write("ID zvířete k označení adopce: ");
            if (int.TryParse(Console.ReadLine(), out int id) && Evidence.OznacAdopci(id))
                Console.WriteLine("Adopce označena.");
            else
                Console.WriteLine("Zvíře nenalezeno nebo již adoptováno.");
        }
    }
}