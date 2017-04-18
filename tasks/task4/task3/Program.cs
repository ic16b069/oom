using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace task3
{


    interface Verkauf
    {
        string Einheit { get; set; }
        decimal Preis_pro_Einheit { get; set; }
    }
    class Artikel:Verkauf
    {
        public string Artikelnummer { get; set; }
        public string Einheit { get; set; }
        public decimal Preis_pro_Einheit { get; set; }

        [JsonConstructor]
        public Artikel(string artikelnummer, string einheit, decimal preis_pro_Einheit)
        {
            if (preis_pro_Einheit <= 0) throw new ArgumentOutOfRangeException("Der Preis muss groesser als 0 sein");
            if (string.IsNullOrWhiteSpace(artikelnummer)) throw new ArgumentException("Artikelnummer darf nicht leer sein", nameof(artikelnummer));
            Artikelnummer = artikelnummer;
            Einheit = einheit;
            Preis_pro_Einheit = preis_pro_Einheit;


        }


        

      

    }
    class Muster : Verkauf
    {
        public string Einheit { get; set; }
        public decimal Preis_pro_Einheit { get; set; }
        public string Herkunft { get; set; }

        [JsonConstructor]
        public Muster(string herkunft, string einheit, decimal preis_pro_Einheit)
        {
            if (preis_pro_Einheit <= 0) throw new ArgumentOutOfRangeException("Der Preis muss groesser als 0 sein");
            if (string.IsNullOrWhiteSpace(herkunft)) throw new ArgumentException("Das Herkunftsland darf nicht leer sein.", nameof(herkunft));
            Preis_pro_Einheit = preis_pro_Einheit;
            Einheit = einheit;
            Herkunft=herkunft;
        }


        static void Main(string[] args)
        {
            Artikel Rohrisolierschlauch = new Artikel("0001", "lfm", 10);
            Artikel Mineralwolle = new Artikel("0002", "m²", 20);
            Artikel Schallschutz = new Artikel("0003", "m²", 30);
            Artikel Proficutter = new Artikel("0004", "Stk", 5);
            Artikel Brandschutzband = new Artikel("0005", "Rol", 150);
            Muster Iso1 = new Muster("Italien", "m²",500);
            Muster Iso2 = new Muster("Polen", "m²", 300);
            Muster Iso3 = new Muster("Tschechien", "m²", 150);
            int Anzahl_Brandschutz = int.Parse(Console.ReadLine());
            int Anzahl_Mineralwolle = int.Parse(Console.ReadLine());
            int Anzahl_Proficutter = int.Parse(Console.ReadLine());
            int Anzahl_Rohrisolierschlauch = int.Parse(Console.ReadLine());
            Console.WriteLine("Mineralwollpreis alt: {0}", Mineralwolle.Preis_pro_Einheit);
            Quartals_erhohung(Mineralwolle.Preis_pro_Einheit);



            var verkauf = new Verkauf[]
            {
                new Artikel("0006", "Stk", 12),
                new Artikel("0007", "lfm", 25),
                new Muster("Frankreich", "Stk",500),
                new Muster("Deutschland", "lfm", 300),
            };


            Console.WriteLine("Der Preis für {0}  {1} Rohrisolierschlauch = {2} ", Anzahl_Rohrisolierschlauch, Rohrisolierschlauch.Einheit, Rohrisolierschlauch.Preis_pro_Einheit * Anzahl_Rohrisolierschlauch);
            Console.WriteLine("Der Preis für {0}  {1} Proficutter = {2} ", Anzahl_Proficutter, Proficutter.Einheit, Proficutter.Preis_pro_Einheit * Anzahl_Proficutter);
            Console.WriteLine("Der Preis für {0}  {1} Mineralwolle = {2} ", Anzahl_Mineralwolle, Mineralwolle.Einheit, Mineralwolle.Preis_pro_Einheit * Anzahl_Mineralwolle);
            Console.WriteLine("Der Preis für {0}  {1} Brandschutzband = {2} ", Anzahl_Brandschutz, Brandschutzband.Einheit, Brandschutzband.Preis_pro_Einheit * Anzahl_Brandschutz);
            
            Json.Run(verkauf);
        }
        public static void Quartals_erhohung(decimal Preis_pro_Einheit)
        {
            Console.WriteLine("Mineralwollpreis neu: {0}", 2 * Preis_pro_Einheit);
        }
        
           
    }

}
