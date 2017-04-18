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

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

            var text = JsonConvert.SerializeObject(verkauf, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "verkauf.json");
            File.WriteAllText(filename, text);

            var textFromFile = File.ReadAllText(filename);
            var verkaufFromFile = JsonConvert.DeserializeObject<Verkauf[]>(textFromFile, settings);
            Console.WriteLine($"{ textFromFile}");
            Console.WriteLine($"{ verkaufFromFile}");
            
        }
    }
    
}
