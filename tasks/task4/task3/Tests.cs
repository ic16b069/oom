using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace task3
{
    [TestFixture]

    public class Tests
    {
        [Test]
        public void Artikelkannerzeugtwerden()
        {
            var test = new Artikel("10", "Stk", 20);
            Assert.IsTrue(test.Artikelnummer == "10");
            Assert.IsTrue(test.Einheit == "Stk");
            Assert.IsTrue(test.Preis_pro_Einheit == 20);
        }


        [Test]
        public void KeinArtikelohneArtikelnummer()
        {
            Assert.Catch(() =>
            {
                var test = new Artikel("", "lfm", 26);
            });
        }
        [Test]
        public void KeinArtikelohneArtikelnummer2()
        {
            Assert.Catch(() =>
            {
                var test = new Artikel(null, "lfm", 26);
            });
        }

        [Test]
        public void Musterkannerzeugtwerden()
        {
            var test = new Muster("Italien", "lfm", 50);
            Assert.IsTrue(test.Herkunft == "Italien");
            Assert.IsTrue(test.Einheit == "lfm");
            Assert.IsTrue(test.Preis_pro_Einheit == 50);
        }

        [Test]
        public void KeinMusterohneHerkunftsland1()
        {
            Assert.Catch(() =>
            {
                var test = new Muster("", "lfm", 26);
            });
        }

        [Test]
        public void KeinMusterohneHerkunftsland2()
        {
            Assert.Catch(() =>
            {
                var test = new Muster(null, "lfm", 26);
            });
        }
        [Test]
        public void KeinArtikelmitnegativemPreis()
        {
            Assert.Catch(() =>
            {
                var test = new Artikel("10", "lfm", -26);
            });
        }
        [Test]
        public void KeinMustermitnegativemPreis()
        {
            Assert.Catch(() =>
            {
                var test = new Muster("Italien", "lfm", -26);
            });
        }

    }
}
