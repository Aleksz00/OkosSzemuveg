using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkosSzemuveg
{
    internal class Szemuveg
    {
        public string Sorszam { get; set; }
        public double Kijelzomeret { get; set; }
        public double Procteljesitmeny { get; set; }
        public int KameraFelb { get; set; }
        public string Szenzorokfel { get; set; }
        public string Tarhelymeret { get; set; }
        public int Uzemido { get; set; }
        public double Centi() => Kijelzomeret * 2.54;
        public int Tar() => int.Parse(Tarhelymeret.Split(" ")[0]);
        public string[] szenzorok => Szenzorokfel.Split(",");
        public int szenzor() => Szenzorokfel.Split(",").Length;
        public Szemuveg(string s)
        {
            string [] a = s.Split(";");
            Sorszam = a[0];
            Kijelzomeret = double.Parse(a[1]);
            Procteljesitmeny = double.Parse(a[2]);
            KameraFelb = int.Parse(a[3]);
            Szenzorokfel = a[4];
            Tarhelymeret = a[5];
            Uzemido = int.Parse(a[6]);
           

        }
        public override string ToString() => $"{Sorszam},  |  {Kijelzomeret}  |  {Procteljesitmeny}  |  {KameraFelb}  |  {Szenzorokfel}  |  {Tarhelymeret}  |  {Uzemido}";
        
    }
}
