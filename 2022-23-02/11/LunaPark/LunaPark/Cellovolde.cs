using System;
using System.Collections.Generic;

namespace LunaPark
{
    class Céllövölde
    {
        public class NincsVendégException : Exception { }
        public class FoglaltAjándékException : Exception { }
        public class LétezőAjándékException : Exception { }

        public readonly string hely;

        public List<Ajándék> Ajándékok { get; }
        public List<Vendég> Vendégek { get; }
        public Céllövölde(string hely) 
        { 
            this.hely = hely; 
            Ajándékok = new ();
            Vendégek = new (); 
        }
        public void Kiállít(Ajándék ajándék) 
        {
            if (ajándék.Céllövölde != null) throw new FoglaltAjándékException();
            if (Ajándékok.Contains(ajándék)) throw new LétezőAjándékException();
            ajándék.Céllövölde = this;
            Ajándékok.Add(ajándék);
        }
        public void Regisztrál(Vendég vendég) { Vendégek.Add(vendég); }
        public string Legjobb()
        {
            if (Vendégek.Count  == 0) throw new NincsVendégException();

            int max = Vendégek[0].Eredmény(this);
            Vendég elem = Vendégek[0];
            foreach (Vendég e in Vendégek)
            {
                int p = e.Eredmény(this);
                if (p > max)
                {
                    max = p; elem = e;
                }
            }
            return elem.név;
        }
    }
}
