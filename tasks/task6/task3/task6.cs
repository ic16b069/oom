using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace task3
{
    public static class task6
    {
        public static void Try()
        {
            // Hier wird unser eigener Observable erstellt
            var versuch = new Subject<Artikel>();
            // gibt die gepushten artikel auf der Konsole aus
            versuch.Subscribe(x => Console.WriteLine($"Artikelnummer:{x.Artikelnummer}  Einheit:{x.Einheit}   Preis/Einheit:{x.Preis_pro_Einheit}"));


            for (var k = 1; k < 10; k++)
            {
                // Thread der neue artikel an den subscriber pusht (alle 1 sekunden)
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
                versuch.OnNext(new Artikel($"{k}", "Stk", k + 10 ) );
            }
        }

    }
}
