using System;

namespace LunaPark
{
    class Program
    {
        static void Main()
        {
            // kell egy-két céllövölde
            Céllövölde c1 = new("bejárat melletti");
            Céllövölde c2 = new("bazársor végi");

            // kell néhány ajándék a céllövöldékbe
            Ajándék a1 = new Labda(S.Instance());
            c1.Kiállít(a1);
            Ajándék a2 = new Labda(M.Instance());
            c1.Kiállít(a2);
            Ajándék a3 = new Plüss(XL.Instance());
            c2.Kiállít(a3);
            Ajándék a4 = new Figura(L.Instance());
            c2.Kiállít(a4);
            Ajándék a5 = new Figura(L.Instance());
            c2.Kiállít(a5);

            // kell néhány vendég, akik elmennek lőni

            Vendég v1 = new("Zsolti");
            Vendég v2 = new("Karcsi");
            v1.Látogat(c1);
            v2.Látogat(c1);
            v1.Látogat(c2);
            v2.Látogat(c2);

            // a vendégek nyernek
            v1.Nyer(a1);
            v2.Nyer(a2);
            v1.Nyer(a3);
            v2.Nyer(a4);
            v2.Nyer(a5);

            // megkérdezzük a céllövöldéktõl, hogy ki legjobb vendégük
            Console.WriteLine(
                $"A(z) {c1.hely} céllövöldében {c1.Legjobb()} volt a legügyesebb vendég."
            );
            Console.WriteLine(
                $"A(z) {c2.hely} céllövöldében {c2.Legjobb()} volt a legügyesebb vendég."
            );
        }
    }
}
