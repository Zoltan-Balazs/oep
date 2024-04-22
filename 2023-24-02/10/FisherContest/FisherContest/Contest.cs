using System;
using System.Collections.Generic;

namespace Fisher_Contest
{
    public class Contest
    {
        public string place { get; }
        public DateTime start { get; }
        private List<Fisher> contestants;
        private Organization org;

        public Contest(Organization org, string place, DateTime start)
        {
            this.org = org;
            this.place = place;
            this.start = start;
            this.contestants = new List<Fisher>();
        }

        public class IncorrectRegistrationException : Exception { }

        public void Register(Fisher fisher)
        {
            if (!org.IsMember(fisher) && contestants.Contains(fisher))
            {
                throw new IncorrectRegistrationException();
            }
            contestants.Add(fisher);
        }

        public double TotalValue()
        {
            double sum = 0.0;
            foreach (Fisher fisher in contestants)
            {
                sum += fisher.TotalValue(this);
            }

            return sum;
        }

        public bool AllCaughtCatfish()
        {
            foreach (Fisher fisher in contestants)
            {
                if (!fisher.CaughtCatfish(this))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
