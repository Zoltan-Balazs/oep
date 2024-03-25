using System;
using System.Collections.Generic;
using System.Text;

namespace Fisher_Contest
{
    public class Contest
    {
        public class AlreadyRegistratedExeption : Exception { }

        public class FisherNotRegistratedExeption : Exception { }

        public readonly string place;
        public DateTime Start { get; }
        private readonly Organization org;
        private readonly List<Fisher> fishers = new();

        public Contest(Organization org, string place, DateTime start)
        {
            this.org = org;
            this.place = place;
            Start = start;
        }

        public void SignUp(Fisher fisher)
        {
            if (!org.Members.Contains(fisher))
                throw new FisherNotRegistratedExeption();
            if (fishers.Contains(fisher))
                throw new AlreadyRegistratedExeption();
            fishers.Add(fisher);
        }

        public double TotalAmount()
        {
            double s = 0.0;
            foreach (Fisher f in fishers)
            {
                s += f.TotalValue(this);
            }
            return s;
        }

        public bool AllCatfishes()
        {
            foreach (Fisher f in fishers)
            {
                if (f.CatfishNumber(this) == 0)
                    return false;
            }
            return true;
        }
    }
}
