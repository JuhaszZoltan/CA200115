using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA200115
{
    struct Hotel
    {
        public string Nev;
        public int FelPanzioAr;
        public int TeljesEllatasAr;
        public int FerohelySzam;
    }
    class Program
    {
        static List<Hotel> hotelek;

        static void Main()
        {
            Beolvasas();
            //Teszt();
            Kiiras();
            NagyBefogadokepesseguHotelek();
            MindenholTeljesEllatas();
            SzazAlattiFerohelyuHotelek();
            AtlagosFelpanziosAr();
            HotelBeker();

            Console.ReadKey();
        }

        private static void HotelBeker()
        {
            Console.Write("Írd be a hotel/panzió nevét: ");
            var hNev = Console.ReadLine();

            int i = 0;
            while (i < hotelek.Count && hotelek[i].Nev.ToLower() != hNev.ToLower())
            {
                i++;
            }

            if(i < hotelek.Count)
            {
                Console.WriteLine($"{hNev} adatai:");
                Console.WriteLine($"\tteljes ellátás ára: {hotelek[i].TeljesEllatasAr} Ft");
                Console.WriteLine($"\tfélpanzió ára:      {hotelek[i].FelPanzioAr} Ft");
                Console.WriteLine($"\tférőhelyek száma:   {hotelek[i].FerohelySzam} fő");
            }
            else
            {
                Console.WriteLine("nincs is ilyen hotel :'(");
            }
        }

        private static void AtlagosFelpanziosAr()
        {
            int sum = 0;
            int db = 0;
            foreach (var h in hotelek)
            {
                if(h.Nev.ToLower().Contains("panzió"))
                {
                    sum += h.FelPanzioAr;
                    db++;
                }
            }
            Console.WriteLine(
                "A panziók félpanziós átlagára: {0:0.00} Ft",
                sum/(float)db);
        }

        private static void SzazAlattiFerohelyuHotelek()
        {
            int db = 0;
            foreach (var h in hotelek)
            {
                if(h.FerohelySzam < 100) db++;
            }
            Console.WriteLine(
                $"A 100 alatti főrőhelyű hotelek száma: {db}");
        }

        private static void MindenholTeljesEllatas()
        {
            int sum = 0;
            foreach (var h in hotelek)
            {
                sum += h.TeljesEllatasAr;
            }
            Console.WriteLine(
                $"\n\nHa az összes hotelben eltöltünk egy napot " +
                $"teljes ellátással {sum} Ft-ba fog fájni");
        }

        private static void NagyBefogadokepesseguHotelek()
        {
            Console.WriteLine("NAGY BEFOGADÓ KÉPESSÉGŰEK");

            foreach (var h in hotelek)
            {
                if(h.FerohelySzam > 300)
                {
                    Console.WriteLine($"{h.Nev}: {h.FerohelySzam} fő");
                }
            }
        }

        private static void Kiiras()
        {
            foreach (var h in hotelek)
            {
                Console.WriteLine(
                    $"{h.Nev} félpanzió: {h.FelPanzioAr}Ft, " +
                    $"teljes ellátás: {h.TeljesEllatasAr}Ft\n" +
                    $"férőhely: {h.FerohelySzam} fő\n");
            }
        }

        private static void Teszt()
        {
            Console.WriteLine(hotelek[2].Nev);
        }

        private static void Beolvasas()
        {
            hotelek = new List<Hotel>();

            var sr = new StreamReader(@"..\..\Res\hotel.txt",Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                var sor = sr.ReadLine().Split(';');
                var h = new Hotel()
                {
                    Nev = sor[0],
                    FelPanzioAr = int.Parse(sor[1]),
                    TeljesEllatasAr = int.Parse(sor[2]),
                    FerohelySzam = int.Parse(sor[3]),
                };
                hotelek.Add(h);
            }
        }

        private static void ListaBev()
        {
            var lista = new List<int>();

            Console.WriteLine($"jelenleg {lista.Count} elemet tartalmaz");

            lista.Add(30);

            int x = 42;

            lista.Add(x);

            lista.Add(100 - 32);

            Console.WriteLine($"jelenleg {lista.Count} elemet tartalmaz");

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i}. elem: {lista[i]}");
            }

            Console.WriteLine("------------");

            lista.Add(42);

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i}. elem: {lista[i]}");
            }

            Console.WriteLine($"jelenleg {lista.Count} elemet tartalmaz");

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i}. elem: {lista[i]}");
            }

        }
    }
}
