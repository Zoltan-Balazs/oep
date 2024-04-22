namespace Fisher_Contest
{
    public abstract class Fish
    {
        public virtual int Multiplier()
        {
            return 0;
        }

        public virtual bool IsBream()
        {
            return false;
        }

        public virtual bool IsCarp()
        {
            return false;
        }

        public virtual bool IsCatfish()
        {
            return false;
        }
    }

    class Bream : Fish
    {
        public override int Multiplier()
        {
            return 2;
        }

        private static Bream instance;

        public static Bream Instance()
        {
            if (null == instance)
            {
                instance = new Bream();
            }

            return instance;
        }
    }

    class Carp : Fish
    {
        public override int Multiplier()
        {
            return 1;
        }

        private static Carp instance;

        public static Carp Instance()
        {
            if (null == instance)
            {
                instance = new Carp();
            }

            return instance;
        }
    }

    class Catfish : Fish
    {
        public override int Multiplier()
        {
            return 3;
        }

        private static Catfish instance;

        public static Catfish Instance()
        {
            if (null == instance)
            {
                instance = new Catfish();
            }

            return instance;
        }
    }
}
