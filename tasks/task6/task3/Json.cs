using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace task3
{
    class Json
    {
        public static void Run(Verkauf[] verkauf)
        {
            // Settings für den Json serialize ( spezielle Formatierung für den json textwriter , und typenamehandling)
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            // konvertiert das Verkauf array in json types mit den gewählten einstellungen
            var text = JsonConvert.SerializeObject(verkauf, settings);
            // gibt den Dateipdfad bis zum Desktop an 
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // kombiniert den Dateipfad zum Desktop mit dem Filenamen der .json Datei
            var filename = Path.Combine(desktop, "verkauf.json");
            //  Schreibt den gesamte Verkauf array (json formatiert) in die.json Datei
            File.WriteAllText(filename, text);

            //liest den Text aus der.json Datei in dei variable textFromFile
            var textFromFile = File.ReadAllText(filename);
            // deserialisiert die.json Datei 
            var verkaufFromFile = JsonConvert.DeserializeObject<Verkauf[]>(textFromFile, settings);
            // Ausgabe json formatiert und deserialisiert aus der Datei
            Console.WriteLine($"{ textFromFile}");
            Console.WriteLine($"{ verkaufFromFile}");
            foreach (var x in verkaufFromFile) Console.WriteLine($"{x.Einheit} {x.Preis_pro_Einheit}");

        }
    }
    
}
