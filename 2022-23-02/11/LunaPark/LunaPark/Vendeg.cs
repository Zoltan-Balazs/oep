using System;
using System.Collections.Generic;
using static LunaPark.Céllövölde;

namespace LunaPark
{
    class Vendég
    {
        public class MárVanIlyenAjándékException : Exception { }

        public class NincsIlyenAjándékException : Exception { }

        public readonly string név;
        public List<Ajándék> Nyeremények { get; }

        public Vendég(string név)
        {
            this.név = név;
            Nyeremények = new List<Ajándék>();
        }

        public void Látogat(Céllövölde c)
        {
            c.Regisztrál(this);
        }

        public void Nyer(Ajándék ajándék)
        {
            if (Nyeremények.Contains(ajándék))
                throw new MárVanIlyenAjándékException();
            if (ajándék.Céllövölde == null)
                throw new NincsIlyenAjándékException();
            ajándék.Céllövölde.Ajándékok.Remove(ajándék);
            Nyeremények.Add(ajándék);
        }

        public int Eredmény(Céllövölde c)
        {
            int s = 0;
            foreach (Ajándék a in Nyeremények)
            {
                if (a.Céllövölde == c)
                {
                    s += a.Érték();
                }
            }
            return s;
        }
    }
}
