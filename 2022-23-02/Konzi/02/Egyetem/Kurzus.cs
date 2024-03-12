using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyetem
{
    internal class Kurzus 
    {
        public string nev;
        public List<Vizsga> vizsgak = new List<Vizsga>();
        public List<Hallgato> hallgatok = new List<Hallgato>();

        public Kurzus(string nev) 
        {
            this.nev = nev;
        }

        public void Felvesz(Hallgato hallg) 
        {
            /*
            if (hallgatok.Contains(hallg))
            {
                throw new Exception("Hiba a kurzus felvételénél");
            }
            */
            foreach (Hallgato e in hallgatok) 
            {
                if (e == hallg) 
                {
                    throw new Exception("Hiba a kurzus felvételénél");
                }
            }
            hallgatok.Add(hallg);
        }

        public Vizsga VizsgatHirdet(string dat, char tip) 
        {
            foreach (Vizsga e in vizsgak) 
            {
                if (e.datum == dat) 
                {
                    throw new Exception("Hiba a vizsga létrehozásában");
                }
            }
            
            Vizsga vizsga;

            switch (tip) {
                case 'N':
                    vizsga = new Normal(dat, this);
                    break;
                case 'U':
                    vizsga = new Uto(dat, this);
                    break;
                default:
                    throw new Exception("Hiba a vizsga létrehozásában");
            }

            vizsgak.Add(vizsga);

            return vizsga;
        }

        public bool VanUtoVizsga() 
        {
            foreach (Vizsga e in vizsgak) 
            {
                if (e.Is_Uto()) 
                {
                    return true;
                }
            }
            return false;
        }

        public bool LegtobbHelyszin(out string helyszin) 
        {
            helyszin = "";

            int max = 0;

            foreach (Vizsga e in vizsgak) 
            {
                if (max < e.helyek.Count) 
                {
                    max = e.helyek.Count;
                    helyszin = e.datum;
                }
            }

            return max == 0;
        }

        /* Vagy
        public (bool, string) LegtobbHelyszin()
        {
            (int, string) max = (-1, "");

            foreach (Vizsga e in vizsgak) 
            { 
                if (max.Item1 < e.helyek.Count)
                {
                    max = (e.helyek.Count, e.datum);
                }
            }

            return (max.Item1 != -1, max.Item2);
        }
        */

        /* Vagy
        public bool LegtobbHelyszin(out string helyszin)...
        */

        /* Vagy
        public string LegtobbHelyszin()...
        */
    }
}