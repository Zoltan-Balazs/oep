namespace LunaPark
{
    interface IMéret
    {
        int Szorzó();
    }

    class S : IMéret
    {
        private static S instance;
        private S() { }
        public static S Instance()
        {
            instance ??= new S();
            return instance;
        }

        public int Szorzó() {return 1;}
    }

    class M : IMéret
    {
        private static M instance;
        private M() { }
        public static M Instance()
        {
            instance ??= new M();
            return instance;
        }
        public int Szorzó() { return 2; }
    }

    class L : IMéret
    {
        private static L instance;
        private L() { }
        public static L Instance()
        {
            instance ??= new L();
            return instance;
        }
        public int Szorzó() { return 3; }
    }

    class XL : IMéret
    {
        private static XL instance;
        private XL() { }
        public static XL Instance()
        {
            instance ??= new XL();
            return instance;
        }
        public int Szorzó() { return 4; }
    }
}
