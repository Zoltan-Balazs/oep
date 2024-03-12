using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Fisher_Contest
{
    public class Organization
    {
        public class MemberAlreadyException : Exception { }
        public class ExistingContestException : Exception { }

        private readonly List<Contest> contests = new ();
        public List<Fisher> Members { get; } = new ();

        public Fisher Join(string name)
        {
            if (Search(name) != null) throw new MemberAlreadyException ();
            Fisher fisher = new (name);
            Members.Add(fisher);
            return fisher;
        }

        public Fisher Search(string name)
        {
            foreach (Fisher fisher in Members)
            {
                if (fisher.name == name) return fisher;
            }
            return null;
        }

        public Contest Organize(string place, DateTime start)
        {
            bool l = false;
            foreach (Contest c in contests)
            {
                if (l = (c.place == place) && c.Start == start) break;
            }
            if (l) throw new ExistingContestException();

            Contest contest = new (this, place, start);
            contests.Add(contest);
            return contest;
        }
        public bool BestContest(out Contest contest)
        {
            bool l = false;
            contest = null;
            double max = 0.0;
            foreach (Contest c in contests)
            {
                if (!c.AllCatfishes()) continue;
                double s = c.TotalAmount();
                if (l)
                {
                    if (s > max)
                    {
                        contest = c; max = s;
                    }
                }
                else
                {
                    l = true; contest = c; max = s;
                }
            }
            return l;
        }
    }
}
