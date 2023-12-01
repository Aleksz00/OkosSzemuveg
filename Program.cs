using System.Threading.Channels;

namespace OkosSzemuveg
{
    internal class Program
    {
        static List<Szemuveg> kamera(List<Szemuveg> a)
        {
            var f7 = a.Where(x => x.KameraFelb >= 12 && x.Procteljesitmeny == 2).ToList();
            return f7;
        }
        static (List<Szemuveg>, double) atlag(List<Szemuveg> b)
        {
            var f8a = b.Average(x => x.Uzemido);
            var f8b = b.Where(x => x.Uzemido > f8a).ToList();
            return (f8b, f8a);
        }
        static List<Szemuveg> tarhely(List<Szemuveg> c)
        {
            var f10 = c.Where(x => x.Tar() < 100).ToList();
            return f10;
        }
        static List<Szemuveg> TB(List<Szemuveg> d)

        {
            var f12 = d.Where(x => x.Tarhelymeret.Contains("TB")).ToList();
            return f12;
        }
        static List<Szemuveg> szen(List<Szemuveg> e)
        {
            var f13 = e.Where(x => x.szenzor() >=3).ToList();
            return f13;
        }
        static List<string> szenzorokred(List<Szemuveg> g)
        {
            var f11 = g.SelectMany(x => x.szenzorok).
                Select(x => (x == "accelerometer") ? "gyorsulásmérő" : x).
                Select(x => (x == "gyroscope") ? "giroszkóp" : x).OrderBy(x => x).Distinct().ToList();

            return f11;
        }
        static List<string> hagyomany(List<Szemuveg> h)
        {
            List<string> szenzorlista = new(); 
            for (int i = 0; i < h.Count; i++)
            {
                for (int a = 0; a < h[i].szenzorok.Length; a++)
                {
                    if (h[i].szenzorok[a] == "accelerometer")
                    {
                        szenzorlista.Add("gyorsulásmérő");
                    }
                    else
                    {
                        
                        if (h[i].szenzorok[a] == "gyroscope")
                        {
                           szenzorlista.Add( "giroszkóp");
                        }
                        else
                        {
                            szenzorlista.Add(h[i].szenzorok[a]);
                        }
                    }

                }

            }
            szenzorlista.Sort();

            return szenzorlista.Distinct().ToList();
        }
        static void Main(string[] args)
        {
            var szemuvegek = new List<Szemuveg>();
            using (var sr = new StreamReader(@"..\..\..\src\okosszemuvegek.txt"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    szemuvegek.Add(new Szemuveg(sr.ReadLine()));
                }
            }
            szemuvegek.ForEach(c => Console.WriteLine(c));
            Console.WriteLine("7.feladat");
            kamera(szemuvegek).ForEach(c => Console.WriteLine(c));
            Console.WriteLine($"{kamera(szemuvegek).Count} db");
            Console.WriteLine("8.feladat");
            (List<Szemuveg> atlaguzem, double f8a) = atlag(szemuvegek);
            foreach (var item in atlaguzem)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"{f8a} %");
            Console.WriteLine($"{atlaguzem.Count} db");
            Console.WriteLine("10.feladat");
            tarhely(szemuvegek).ForEach(c => Console.WriteLine($"{c.Sorszam} sorszám, {c.Tar()} cm"));
            Console.WriteLine("11.feladat");
            szenzorokred(szemuvegek).ForEach(c => Console.WriteLine(c));
            Console.WriteLine("2.megoldas");
            hagyomany(szemuvegek).ForEach(c => Console.WriteLine(c));
            Console.WriteLine("12.feladat");
            TB(szemuvegek).ForEach(c => Console.WriteLine(c));
            Console.WriteLine("13.feladat");
            szen(szemuvegek).ForEach(c => Console.WriteLine(c));
            using (var sw = new StreamWriter(@"..\..\..\src\adatok.txt"))
            {
                foreach (var item in szen(szemuvegek))
                {
                   sw.WriteLine($"{item}");
                }
            }
        }
    }
}