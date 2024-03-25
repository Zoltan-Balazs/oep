using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egyetem
{
    internal class Vizsga
    {
        public string datum;
        public List<Hely> helyek = new List<Hely>();
        public Kurzus kurzus;

        public Vizsga(string datum, Kurzus kurzus)
        {
            this.datum = datum;
            this.kurzus = kurzus;
            // helyek = new List<Hely>()
        }

        public void TermetHozzaAd(Hely hely)
        {
            foreach (Hely e in helyek)
            {
                if (e.terem == hely.terem)
                {
                    throw new Exception("Hiba a teremhozzáadásban");
                }
            }
            helyek.Add(hely);
        }

        public void Jelentkezik(Hallgato hallg, Hely hely)
        {
            bool isStudentOnCourse = false;
            foreach (Hallgato e in kurzus.hallgatok)
            {
                if (e == hallg)
                {
                    isStudentOnCourse = true;
                }
            }
            if (!isStudentOnCourse)
            {
                throw new Exception("Hiba a jelentkezésnél (Hallgató nem jelentkezett a kurzusra)");
            }

            bool isExamHeldAtLocation = false;
            foreach (Hely e in helyek)
            {
                if (e == hely)
                {
                    isExamHeldAtLocation = true;
                }
            }
            if (!isExamHeldAtLocation)
            {
                throw new Exception(
                    "Hiba a jelentkezésnél (A helyen nincs meghírdetve egy vizsga sem a kurzusra)"
                );
            }

            foreach (Hallgato e in hely.hallgatok)
            {
                if (e == hallg)
                {
                    throw new Exception(
                        "Hiba a jelentkezésnél (A hallgató már felvette az adott helyre a visgát)"
                    );
                }
            }

            hely.hallgatok.Add(hallg);
        }

        public int HanyHallgato()
        {
            int sum = 0;
            foreach (Hely e in helyek)
            {
                sum += e.hallgatok.Count;
            }
            return sum;
        }

        public Hely KedveltHely()
        {
            int max = -1;
            Hely kedveltHely = null;

            foreach (Hely e in helyek)
            {
                if (max < e.hallgatok.Count)
                {
                    max = e.hallgatok.Count;
                    kedveltHely = e;
                }
            }

            return kedveltHely;
        }

        public virtual bool Is_Norm()
        {
            return false;
        }

        public virtual bool Is_Uto()
        {
            return false;
        }
    }

    internal class Normal : Vizsga
    {
        public Normal(string datum, Kurzus kurzus)
            : base(datum, kurzus) { }

        public override bool Is_Norm()
        {
            return true;
        }
    }

    internal class Uto : Vizsga
    {
        public Uto(string datum, Kurzus kurzus)
            : base(datum, kurzus) { }

        public override bool Is_Uto()
        {
            return true;
        }
    }
}
